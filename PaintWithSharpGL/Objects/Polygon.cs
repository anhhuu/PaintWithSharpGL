using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Polygon : Shape
    {
        public bool Completed { get; set; }

        public Polygon(Point start, Point end, Color color, int lineWidth)
        {
            VerticesControl = new List<Point>();
            this.Color = color;
            this.LineWidth = lineWidth;
            Completed = false;
        }

        private Point Point;

        public Point StartPoint
        {
            get { return Point; }
            set
            {
                Point = value;
                VerticesControl.Add(Point);
            }
        }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public List<Point> VerticesControl { get; set; }

        public void DrawWithOpenGLBuildIn(OpenGL gl)
        {
            //Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            gl.Begin(OpenGL.GL_LINE_LOOP);
            foreach (Point item in VerticesControl)
            {
                gl.Vertex(item.X, item.Y);
            }
            if (!Completed)
            {
                gl.Vertex(EndPoint.X, EndPoint.Y);
            }
            gl.End();
            gl.Flush();
        }

        public void DrawWithTheoreticalAlgorithm(OpenGL gl)
        {
            DrawWithOpenGLBuildIn(gl);
        }

        public string getTypeOfObject()
        {
            return "Polygon";
        }
    }
}
