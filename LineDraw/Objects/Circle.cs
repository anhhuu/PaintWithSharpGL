using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw.Objects
{
    class Circle : Shape
    {
        private double radius;
        private const double DEGTORAD = 3.14159 / 180;

        private Point center;
        private Point borderPoint;

        public Circle(Point start, Point end)
        {
            this.center = start;
            this.borderPoint = end;
            radius = Math.Sqrt((center.X - borderPoint.X) * (center.X - borderPoint.X) + (center.Y - borderPoint.Y) * (center.Y - borderPoint.Y));
        }

        public Point start
        {
            get { return center; }
            set
            {
                center = value;
                radius = Math.Sqrt((center.X - borderPoint.X) * (center.X - borderPoint.X) + (center.Y - borderPoint.Y) * (center.Y - borderPoint.Y));
            }
        }
        public Point end
        {
            get { return borderPoint; }
            set
            {
                borderPoint = value;
                radius = Math.Sqrt((center.X - borderPoint.X) * (center.X - borderPoint.X) + (center.Y - borderPoint.Y) * (center.Y - borderPoint.Y));
            }
        }
        public void drawWithOpenGL(OpenGL gl, Color color)
        {
            Point C = new Point(center.X, gl.RenderContextProvider.Height - center.Y);

            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0); // Chọn màu đỏ
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i <= 360; i++)
            {
                double degInRad = i * DEGTORAD;
                gl.Vertex(Math.Cos(degInRad) * radius + C.X, Math.Sin(degInRad) * radius + C.Y);
            }

            gl.End();
            gl.Flush();
        }
    }
}
