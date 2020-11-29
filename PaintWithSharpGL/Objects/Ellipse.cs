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
        //radius on X axis
        private double RadiusX;

        //radius on Y axis
        private double RadiusY;
        private const double DEGTORAD = 3.14159 / 180;

        //Center of circle
        private Point CenterPoint;

        //The point of the boder circle
        private Point BorderPoint;

        public bool Completed { get; set; }
        public Ellipse(Point start, Point end, Color color, int lineWidth)
        {
            this.CenterPoint = start;
            this.BorderPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            //calc radius
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
        public List<Point> VerticesControl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DrawWithOpenGLBuildIn(OpenGL gl)
        {
			//Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //Divide the circle into 360 arcs, drawing each arc with a line, using GL_LINE_LOOP
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                double degInRad = i * DEGTORAD;
                gl.Vertex(RadiusX * Math.Cos(degInRad) + CenterPoint.X, RadiusY * Math.Sin(degInRad) + CenterPoint.Y);
            }
            gl.End();
            gl.Flush();
        }

        public void DrawWithTheoreticalAlgorithm(OpenGL gl)
        {
			//Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //x_k, y_k
            double x = 0;
            double y = RadiusY; 

            double Rx_Square = Math.Pow(RadiusX, 2);
            double Ry_Square = Math.Pow(RadiusY, 2);

            //initial decision parameter of region 1 
            double P1 = Ry_Square - Rx_Square * RadiusY + (0.25f * Rx_Square);
            double dx = 2 * Ry_Square * x;
            double dy = 2 * Rx_Square * y;

            //for region 1 
            while (dx < dy)
            {
                x++;
                dx += 2 * Ry_Square;
                //checking and updating value of decision parameter based on algorithm 
                if (P1 < 0)
                    P1 += dx + Ry_Square;

                else
                {
                    y--;
                    dy -= 2 * Rx_Square;
                    P1 += dx - dy + Ry_Square;
                }
                //set symmetry pixel at 4 part of ellipse
                Utils.Utils.setPixel((int)(CenterPoint.X + x), (int)(CenterPoint.Y + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X + x), (int)(CenterPoint.Y - y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X - x), (int)(CenterPoint.Y + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X - x), (int)(CenterPoint.Y - y), gl, Color, LineWidth);
            }

            //decision parameter of region 2 
            double P2 = (Ry_Square * ((x + 0.5f) * (x + 0.5f))) + (Rx_Square * ((y - 1) * (y - 1))) - (Rx_Square * Ry_Square);

            //plotting points of region 2 
            while (y >= 0)
            {

                y--;
                dy = dy - (2 * Rx_Square);
                //checking and updating parameter value based on algorithm 
                if (P2 > 0)
                    P2 += Rx_Square - dy;

                else
                {
                    x++;
                    dx += (2 * Ry_Square);
                    P2 += dx - dy + (Rx_Square);
                }
                //set symmetry pixel at 4 part of ellipse
                Utils.Utils.setPixel((int)(CenterPoint.X + x), (int)(CenterPoint.Y + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X + x), (int)(CenterPoint.Y - y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X - x), (int)(CenterPoint.Y + y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(CenterPoint.X - x), (int)(CenterPoint.Y - y), gl, Color, LineWidth);
            }
        }
        public string getTypeOfObject()
        {
            return "Ellipse";
        }
    }
}
