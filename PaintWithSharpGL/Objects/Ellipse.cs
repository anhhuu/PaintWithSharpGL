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
            Point C = new Point(CenterPoint.X, CenterPoint.Y);
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

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            // initialize information to draw ellipse
           
            double xc = CenterPoint.X;
            double yc = CenterPoint.Y;
            double x = 0;
            double y = RadiusY;
            double Rx2 = Math.Pow(RadiusX, 2);
            double Ry2 = Math.Pow(RadiusY, 2);
            // Initial decision parameter of region 1 
            double P1 = Ry2 - Rx2 * RadiusY + (0.25f * Rx2);
            double dx = 2 * Ry2 * x;
            double dy = 2 * Rx2 * y;

            // For region 1 
            while (dx < dy)
            {
                x++;
                dx += 2 * Ry2;
                // Checking and updating value of decision parameter based on algorithm 
                if (P1 < 0)
                    P1 += dx + Ry2;

                else
                {
                    y--;
                    dy -= 2 * Rx2;
                    P1 += dx - dy + Ry2;
                }
                // set symmetry pixel at 4 part of ellipse
                Utils.Utils.setPixel((int)(xc + x), (int)(yc + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc + x), (int)(yc - y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc - x), (int)(yc + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc - x), (int)(yc - y), gl, Color, LineWidth);
            }

            // Decision parameter of region 2 
            double P2 = (Ry2 * ((x + 0.5f) * (x + 0.5f))) + (Rx2 * ((y - 1) * (y - 1))) - (Rx2 * Ry2);

            // Plotting points of region 2 
            while (y >= 0)
            {

                y--;
                dy = dy - (2 * Rx2);
                // Checking and updating parameter value based on algorithm 
                if (P2 > 0)
                    P2 += Rx2 - dy;

                else
                {
                    x++;
                    dx += (2 * Ry2);
                    P2 += dx - dy + (Rx2);
                }
                // set symmetry pixel at 4 part of ellipse
                Utils.Utils.setPixel((int)(xc + x), (int)(yc + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc + x), (int)(yc - y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc - x), (int)(yc + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(xc - x), (int)(yc - y), gl, Color, LineWidth);
            }
        }
        public string getTypeOfObject()
        {
            return "Ellipse";
        }
    }
}
