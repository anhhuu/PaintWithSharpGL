using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.ScanLine
{
    class TestScanLine
    {
        public int XiangSu = 1;
        public int line = 0;
        public OpenGL g = null;
        public void ScanLinePolygonFill(List<Point> Q, OpenGL g, int XiangSu)
        {
            this.XiangSu = XiangSu;
            this.g = g;

            List<EDGE>[] NET = new List<EDGE>[500];//Define a new edge table
            for (int i = 0; i < 500; i++) NET[i] = new List<EDGE>();//Instantiation

            int ymax = 0, ymin = 0;//The maximum and minimum of the polygon y

            GetPolygonMinMax(Q, out ymax, out ymin);//Calculate updates ymax and ymin(ok)
            InitScanLineNewEdgeTable(NET, Q, ymin, ymax);//Initialize a new edge table
            HorizonEdgeFill(Q); //Horizontal line fill directly
            ProcessScanLineFill(NET, ymin, ymax);
        }

        private void HorizonEdgeFill(List<Point> Q)
        {

        }

        private void GetPolygonMinMax(List<Point> Q, out int ymax, out int ymin)
        {
            ymax = -1;
            ymin = 1000;
            for (int i = 0; i < Q.Count; i++)
            {
                if (Q[i].Y > ymax) ymax = Q[i].Y;
                if (Q[i].Y < ymin) ymin = Q[i].Y;
            }
        }

        private void InitScanLineNewEdgeTable(List<EDGE>[] NET, List<Point> Q, int ymin, int ymax)
        {
            List<int> temp = new List<int>();
            EDGE e;
            for (int i = 0; i < Q.Count; i++)
            {
                Point ps = Q[i];
                Point pe = Q[(i + 1) % Q.Count];
                Point pss = Q[(i - 1 + Q.Count) % Q.Count];
                Point pee = Q[(i + 2) % Q.Count];
                if (pe.Y != ps.Y)//Do not process parallel lines
                {
                    e = new EDGE();
                    e.dx = (double)(pe.X - ps.X) / (double)(pe.Y - ps.Y) * XiangSu;
                    if (pe.Y > ps.Y)
                    {
                        e.xi = ps.X;
                        if (pee.Y >= pe.Y)
                            e.ymax = pe.Y - XiangSu;
                        else
                            e.ymax = pe.Y;
                        NET[ps.Y - ymin].Add(e);//Join the corresponding NET
                        temp.Add(ps.Y - ymin);
                    }
                    else
                    {
                        e.xi = pe.X;
                        if (pss.Y >= ps.Y)
                            e.ymax = ps.Y - XiangSu;
                        else
                            e.ymax = ps.Y;
                        NET[pe.Y - ymin].Add(e);//Join the corresponding NET
                        temp.Add(pe.Y - ymin);
                    }
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                My_Sort(ref NET[temp[i]]);
            }
        }

        private void My_Sort(ref List<EDGE> list)
        {
            EDGE d = new EDGE();
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

        private void ProcessScanLineFill(List<EDGE>[] NET, int ymin, int ymax)
        {
            List<EDGE> AET = new List<EDGE>();//Scanning line
            for (int y = ymin; y < ymax; y += XiangSu)
            {
                //g.DrawLine(new Pen(red), new Point(10, y), new Point(20, y));
                //g.DrawString(AET.Count.ToString(), new Font("Microsoft Yahei", 6), blue, new Point(2, y));
                InsertNetListToAet(NET[y - ymin], ref AET);
                //g.DrawString(y + " -> " + NET[y - ymin].Count + " -> " + AET.Count.ToString(), new Font("Microsoft Yahei", 6), blue, new Point(25, y));
                for (int i = 0; i < AET.Count; i++)
                {
                    //g.DrawString((((int)AET[i].xi) / XiangSu * XiangSu).ToString() + " ", new Font("Microsoft Yahei", 6), blue, new Point(400 + i * 24, y));
                }
                FillAetScanLine(ref AET, y);
                RemoveNonActiveEdgeFromAet(ref AET, y);//Delete inactive edges
                UpdateAndResortAet(ref AET);//Update the xi value of each item in the active side table and reorder according to xi
            }
        }

        private void RemoveNonActiveEdgeFromAet(ref List<EDGE> AET, int y)
        {
            line = y;
            AET.RemoveAll(IsEdgeOutOfActive);
        }

        private bool IsEdgeOutOfActive(EDGE obj)
        {
            return line == obj.ymax;
        }
        private void UpdateAetEdgeInfo(EDGE e)
        {
            e.xi += e.dx;
        }
        private void UpdateAndResortAet(ref List<EDGE> AET)
        {
            AET.ForEach(UpdateAetEdgeInfo);
            My_Sort(ref AET);
        }
        private void FillAetScanLine(ref List<EDGE> AET, int y)
        {
            if (AET.Count < 2) return;
            y = y / XiangSu * XiangSu;
            for (int i = 0; i < AET.Count; i += 2)
            {
                int from = ((int)AET[i].xi + XiangSu) / XiangSu * XiangSu;
                int to = ((int)(AET[i + 1].xi + XiangSu / 2)) / XiangSu * XiangSu;
                if (from < to)
                {
                    g.Begin(OpenGL.GL_LINES);
                    g.Vertex(from - XiangSu / 2, y - XiangSu / 2);
                    g.Vertex(to - XiangSu / 2, y - XiangSu / 2);
                    g.End();
                }    
            }
        }
        private void InsertNetListToAet(List<EDGE> list, ref List<EDGE> AET)
        {
            if (list.Count == 0) return;
            if (AET.Count == 0)
            {
                AET = list;
                return;
            }
            List<EDGE> temp = new List<EDGE>();
            int i = 0, j = 0;
            while (i < list.Count && j < AET.Count)
            {
                if (list[i] == AET[j])
                {
                    i++;
                    temp.Add(AET[j]);
                    j++;
                    continue;
                }
                if (list[i] < AET[j])
                {
                    temp.Add(list[i]);
                    i++;
                    continue;
                }
                if (list[i] > AET[j])
                {
                    temp.Add(AET[j]);
                    j++;
                    continue;
                }
            }
            while (i < list.Count)
            {
                temp.Add(list[i]);
                i++;
            }
            while (j < AET.Count)
            {
                temp.Add(AET[j]);
                j++;
            }
            AET = temp;
        }

    }
}
