using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.ScanLine
{
    class ScanLine
    {
        public int LineFilling = 0;
        private Color Color;
        private OpenGL gl = null;
        public void ScanLinePolygonFill(List<Point> VertexControl, OpenGL gl, Color color)
        {
            this.Color = color;
            this.gl = gl;

            List<Edge>[] EdgeTable = new List<Edge>[500];//Define a new edge table
            for (int i = 0; i < 500; i++) EdgeTable[i] = new List<Edge>();//Instantiation

            int ymax = 0, ymin = 0;//The maximum and minimum of the polygon y

            GetPolygonMinMax(VertexControl, out ymax, out ymin);//Calculate updates ymax and ymin(ok)
            InitScanLineNewEdgeTable(EdgeTable, VertexControl, ymin, ymax);//Initialize a new edge table
            ProcessScanLineFill(EdgeTable, ymin, ymax);
        }

        private void GetPolygonMinMax(List<Point> VertexControl, out int ymax, out int ymin)
        {
            ymax = -1;
            ymin = 1000;
            for (int i = 0; i < VertexControl.Count; i++)
            {
                if (VertexControl[i].Y > ymax) ymax = VertexControl[i].Y;
                if (VertexControl[i].Y < ymin) ymin = VertexControl[i].Y;
            }
        }

        private void InitScanLineNewEdgeTable(List<Edge>[] EdgeTable, List<Point> VertexControl, int ymin, int ymax)
        {
            List<int> temp = new List<int>();
            Edge e;
            for (int i = 0; i < VertexControl.Count; i++)
            {
                Point ps = VertexControl[i];
                Point pe = VertexControl[(i + 1) % VertexControl.Count];
                Point pss = VertexControl[(i - 1 + VertexControl.Count) % VertexControl.Count];
                Point pee = VertexControl[(i + 2) % VertexControl.Count];
                if (pe.Y != ps.Y)//Do not process parallel lines
                {
                    e = new Edge();
                    e.ReciSlope = (double)(pe.X - ps.X) / (double)(pe.Y - ps.Y);
                    if (pe.Y > ps.Y)
                    {
                        e.Xi = ps.X;
                        if (pee.Y >= pe.Y)
                            e.Y_Upper = pe.Y - 1;
                        else
                            e.Y_Upper = pe.Y;
                        EdgeTable[ps.Y - ymin].Add(e);//Join the corresponding EdgeTable
                        temp.Add(ps.Y - ymin);
                    }
                    else
                    {
                        e.Xi = pe.X;
                        if (pss.Y >= ps.Y)
                            e.Y_Upper = ps.Y - 1;
                        else
                            e.Y_Upper = ps.Y;
                        EdgeTable[pe.Y - ymin].Add(e);//Join the corresponding EdgeTable
                        temp.Add(pe.Y - ymin);
                    }
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                SortAET(ref EdgeTable[temp[i]]);
            }
        }

        private void SortAET(ref List<Edge> list)
        {
            Edge d = new Edge();
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[i])
                    {
                        d = list[j];
                        list[j] = list[i];
                        list[i] = d;
                    }
                }
            }
        }

        private void ProcessScanLineFill(List<Edge>[] EdgeTable, int ymin, int ymax)
        {
            List<Edge> ActiveEdgeTable = new List<Edge>();//Scanning line
            for (int y = ymin; y < ymax; y += 1)
            {
                InsertNetListToAet(EdgeTable[y - ymin], ref ActiveEdgeTable);
                FillAetScanLine(ref ActiveEdgeTable, y);
                RemoveNonActiveEdgeFromAet(ref ActiveEdgeTable, y);//Delete inactive edges
                UpdateAndResortAet(ref ActiveEdgeTable);//Update the xi value of each item in the active side table and reorder according to xi
            }
        }

        private void RemoveNonActiveEdgeFromAet(ref List<Edge> ActiveEdgeTable, int y)
        {
            LineFilling = y;
            ActiveEdgeTable.RemoveAll(IsEdgeOutOfActive);
        }

        private bool IsEdgeOutOfActive(Edge obj)
        {
            return LineFilling == obj.Y_Upper;
        }
        private void UpdateAetEdgeInfo(Edge e)
        {
            e.Xi += e.ReciSlope;
        }
        private void UpdateAndResortAet(ref List<Edge> ActiveEdgeTable)
        {
            ActiveEdgeTable.ForEach(UpdateAetEdgeInfo);
            SortAET(ref ActiveEdgeTable);
        }
        private void FillAetScanLine(ref List<Edge> ActiveEdgeTable, int y)
        {
            if (ActiveEdgeTable.Count < 2) return;
            for (int i = 0; i < ActiveEdgeTable.Count; i += 2)
            {
                int from = ((int)ActiveEdgeTable[i].Xi + 1);
                int to = ((int)(ActiveEdgeTable[i + 1].Xi));
                if (from < to)
                {
                    gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(from, y);
                    gl.Vertex(to, y);
                    gl.End();
                }
            }
        }
        private void InsertNetListToAet(List<Edge> list, ref List<Edge> ActiveEdgeTable)
        {
            if (list.Count == 0) return;
            if (ActiveEdgeTable.Count == 0)
            {
                ActiveEdgeTable = list;
                return;
            }
            List<Edge> temp = new List<Edge>();
            int i = 0, j = 0;
            while (i < list.Count && j < ActiveEdgeTable.Count)
            {
                if (list[i] == ActiveEdgeTable[j])
                {
                    i++;
                    temp.Add(ActiveEdgeTable[j]);
                    j++;
                    continue;
                }
                if (list[i] < ActiveEdgeTable[j])
                {
                    temp.Add(list[i]);
                    i++;
                    continue;
                }
                if (list[i] > ActiveEdgeTable[j])
                {
                    temp.Add(ActiveEdgeTable[j]);
                    j++;
                    continue;
                }
            }
            while (i < list.Count)
            {
                temp.Add(list[i]);
                i++;
            }
            while (j < ActiveEdgeTable.Count)
            {
                temp.Add(ActiveEdgeTable[j]);
                j++;
            }
            ActiveEdgeTable = temp;
        }

    }
}
