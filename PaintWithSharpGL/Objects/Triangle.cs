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
            this.start = start;
            this.end = end;
            this.color = color;
            this.lineWidth = lineWidth;
        }

        public Point start { get; set; }
        public Point end { get; set; }
        public Color color { get; set; }
        public int lineWidth { get; set; }

        public void drawWithOpenGL(OpenGL gl)
        {
            double degInRad = 60 * DEGTORAD;
            Point A = new Point(start.X, gl.RenderContextProvider.Height - start.Y);
            Point B = new Point(end.X, gl.RenderContextProvider.Height - end.Y);
            Point C = new Point();
            C.X = B.X - A.X;
            C.Y = B.Y - A.Y;

            double xC_last = C.X;
            double yC_last = C.Y;

            C.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
            C.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

            C.X += A.X;
            C.Y += A.Y;

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.LineWidth(lineWidth);

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);   
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);   
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(C.X, C.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(C.X, C.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Flush();
        }
    }
}
