using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw.Objects
{
    class Triangle : Shape
    {
        private const double DEGTORAD = 3.14159 / 180;
        public Triangle(Point start, Point end, Color color, int lineWidth)
        {
            this.StartPoint = start;
            this.EndPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }

        public void DrawWithOpenGL(OpenGL gl)
        {
            double degInRad = 60 * DEGTORAD;
            Point A = new Point(StartPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            Point B = new Point(EndPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            Point C = new Point();
            C.X = B.X - A.X;
            C.Y = B.Y - A.Y;

            double xC_last = C.X;
            double yC_last = C.Y;

            C.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
            C.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

            C.X += A.X;
            C.Y += A.Y;

            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);   
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);   
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            gl.Vertex(C.X, C.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(C.X, C.Y);
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            gl.End();

            gl.Flush();
        }
    }
}
