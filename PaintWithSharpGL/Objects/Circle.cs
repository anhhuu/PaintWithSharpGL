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
        private double Radius;
        private const double DEGTORAD = 3.14159 / 180;

        private Point CenterPoint;
        private Point BorderPoint;

        public Circle(Point start, Point end, Color color, int lineWidth)
        {
            this.CenterPoint = start;
            this.BorderPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
            Point C = new Point(CenterPoint.X, gl.RenderContextProvider.Height - CenterPoint.Y);

            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i <= 360; i++)
            {
                double degInRad = i * DEGTORAD;
                gl.Vertex(Math.Cos(degInRad) * Radius + C.X, Math.Sin(degInRad) * Radius + C.Y);
            }

            gl.End();
            gl.Flush();
        }
    }
}
