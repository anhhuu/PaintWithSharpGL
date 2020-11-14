using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Ellipse : Shape
    {
        private double RadiusX;
        private double RadiusY;
        private const double DEGTORAD = 3.14159 / 180;

        private Point CenterPoint;
        private Point BorderPoint;

        public Ellipse(Point start, Point end, Color color, int lineWidth)
        {
            this.CenterPoint = start;
            this.BorderPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            RadiusX = Math.Abs(CenterPoint.X - BorderPoint.X);
            RadiusY = Math.Abs(CenterPoint.Y - BorderPoint.Y);
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                RadiusX = Math.Abs(CenterPoint.X - BorderPoint.X);
                RadiusY = Math.Abs(CenterPoint.Y - BorderPoint.Y);
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                RadiusX = Math.Abs(CenterPoint.X - BorderPoint.X);
                RadiusY = Math.Abs(CenterPoint.Y - BorderPoint.Y);
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
            Point C = new Point(CenterPoint.X, gl.RenderContextProvider.Height - CenterPoint.Y);
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                double degInRad = i * DEGTORAD;
                gl.Vertex(RadiusX * Math.Cos(degInRad) + C.X, RadiusY * Math.Sin(degInRad) + C.Y);
            }
            gl.End();
            gl.Flush();
        }
    }
}
