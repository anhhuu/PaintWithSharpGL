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
        private double length;
        private const double DEGTORAD = 3.14159 / 180;
        public Triangle(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public Point start { get; set; }
        public Point end { get; set; }
       
        public void drawWithOpenGL(OpenGL gl, Color color)
        {
            Point C = new Point(end.X, gl.RenderContextProvider.Height - end.Y);
            length = Math.Sqrt((start.X - end.X) * (start.X - end.X) + (start.Y - end.Y) * (start.Y - end.Y));
            double degInRad = 60 * DEGTORAD;
            double xC = Math.Cos(degInRad) * length + C.X;
            double yC = Math.Sin(degInRad) * length + C.Y;

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0); // Chọn màu đỏ
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);   
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);   
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(xC, yC);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(xC, yC);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Flush();
        }
    }
}
