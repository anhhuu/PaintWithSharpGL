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
            Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
            //Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
                //Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
                //Radius = Math.Sqrt((CenterPoint.X - BorderPoint.X) * (CenterPoint.X - BorderPoint.X) + (CenterPoint.Y - BorderPoint.Y) * (CenterPoint.Y - BorderPoint.Y));
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

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
            double x = Radius, y = 0;

            // Printing the initial point on the axes  
            // after translation 
            Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);

            // When radius is zero only a single 
            // point will be printed 
            if (Radius > 0)
            {
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-y + CenterPoint.X), (int)(x + CenterPoint.Y), gl, Color, LineWidth);
            }

            // Initialising the value of P 
            double P = 1 - Radius;
            while (x > y)
            {
                y++;

                // Mid-point is inside or on the perimeter 
                if (P <= 0)
                    P = P + 2 * y + 1;

                // Mid-point is outside the perimeter 
                else
                {
                    x--;
                    P = P + 2 * y - 2 * x + 1;
                }

                // All the perimeter points have already been printed 
                if (x < y)
                    break;

                // Printing the generated point and its reflection 
                // in the other octants after translation 
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-x + CenterPoint.X), (int)(y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);
                Utils.Utils.setPixel((int)(-x + CenterPoint.X), (int)(-y + CenterPoint.Y), gl, Color, LineWidth);

                // If the generated point is on the line x = y then  
                // the perimeter points have already been printed 
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
