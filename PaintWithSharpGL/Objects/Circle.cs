using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Circle : Shape
    {
        //constants used in convert degree -> radian
        private const double DEGTORAD = 3.14159 / 180;
        
        //Radius of circle
        private double Radius;

        //Center of circle
        private Point CenterPoint;
        
        //The point of the boder circle
        private Point BorderPoint;

        public Circle(Point start, Point end, Color color, int lineWidth)
        {
            this.CenterPoint = start;
            this.BorderPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            //calc radius
            Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
			//Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //Divide the circle into 360 arcs, drawing each arc with a line, using GL_LINE_LOOP
            gl.Begin(OpenGL.GL_LINE_LOOP);

            for (int i = 0; i <= 360; i++)
            {
                double degInRad = i * DEGTORAD;
                gl.Vertex(Math.Cos(degInRad) * Radius + CenterPoint.X, Math.Sin(degInRad) * Radius + CenterPoint.Y);
            }

            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            double x = Radius, y = 0;  //x_k, y_k

            //setting the initial pixel on the axes after translation 
            Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);

            //when radius is zero only a single pixel will be set
            if (Radius > 0)
            {
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
            }

            //initialising the value of P 
            double p0 = 1 - Radius;
            while (x > y)
            {
                y++;

                //Mid-point is inside or on the perimeter 
                if (p0 <= 0)
                    p0 = p0 + 2 * y + 1;

                //Mid-point is outside the perimeter 
                else
                {
                    x--;
                    p0 = p0 + 2 * y - 2 * x + 1;
                }

                //All the perimeter pixel have already been set
                if (x < y)
                    break;

                //setting the generated pixel and its reflection in the other octants after translation 
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);

                //if the generated pixel is on the line x = y then the perimeter pixel have already been set 
                if (x != y)
                {
                    Utils.Utils.setPixel((int)(y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
                    Utils.Utils.setPixel((int)(-y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
                    Utils.Utils.setPixel((int)(y + CenterPoint.X), (int)(-x + CenterPoint.Y), gl, Color, LineWidth);
                    Utils.Utils.setPixel((int)(-y + CenterPoint.X), (int)(-x + CenterPoint.Y), gl, Color, LineWidth);
                }
            }
        }

        public string getTypeOfObject()
        {
            return "Circle";
        }
    }
}
