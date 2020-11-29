using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Paint.Objects
{
    class Line : Shape
    {
        private bool IsCompleted;
        public Line(Point start, Point end, Color color, int lineWidth)
        {
            this.StartPoint = start;
            this.EndPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            this.IsCompleted = false;
            VerticesControl = new List<Point>();
        }

        public bool Completed
        {
            get { return IsCompleted; }
            set
            {
                IsCompleted = value;
                if (IsCompleted)
                {
                    VerticesControl.Add(StartPoint);
                    VerticesControl.Add(EndPoint);
                }
            }
        }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public List<Point> VerticesControl { get; set; }

        public void DrawWithOpenGLBuildIn(OpenGL gl)
        {
            //Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //Draw line using GL_LINES
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoreticalAlgorithm(OpenGL gl)
        {
            //Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            int dx, dy, i, p0;
            int incX, incY, incGreaterThanOrEqualToZero, incLessThanZero;
            int x, y; //x_k, y_k

            dx = Math.Abs(EndPoint.X - StartPoint.X);
            dy = Math.Abs(EndPoint.Y - StartPoint.Y);

            incX = 1;
            if (EndPoint.X < StartPoint.X)
            {
                incX = -1;
            }

            incY = 1;
            if (EndPoint.Y < StartPoint.Y)
            {
                incY = -1;
            }

            x = StartPoint.X; y = StartPoint.Y;
            if (dx > dy) //0 <= slope < 1
            {
                Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
                p0 = 2 * dy - dx;
                incGreaterThanOrEqualToZero = 2 * (dy - dx); //increased value when Pk less than 0
                incLessThanZero = 2 * dy; //increased value when Pk less than 0
                for (i = 0; i < dx; i++)
                {
                    if (p0 >= 0)
                    {
                        y += incY;
                        p0 += incGreaterThanOrEqualToZero;
                    }
                    else
                    {
                        p0 += incLessThanZero;
                    }
                    x += incX;
                    Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
                }

            }
            else //slope >= 1
            {
                Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
                p0 = 2 * dx - dy;
                incGreaterThanOrEqualToZero = 2 * (dx - dy);
                incLessThanZero = 2 * dx;
                for (i = 0; i < dy; i++)
                {
                    if (p0 >= 0)
                    {
                        x += incX;
                        p0 += incGreaterThanOrEqualToZero;
                    }
                    else
                        p0 += incLessThanZero;
                    y += incY;
                    Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
                }
            }
            gl.Flush();
        }

        public string getTypeOfObject()
        {
            return "Line";
        }
    }
}
