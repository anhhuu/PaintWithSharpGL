using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Line : Shape
    {
       public Line(Point start, Point end, Color color, int lineWidth)
       {
            this.StartPoint = start;
            this.EndPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
       }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }

        public void DrawWithOpenGL(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0); 
            gl.LineWidth(LineWidth);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
			int dx, dy, i, e;
			int incx, incy, inc1, inc2;
			int x, y;

			dx = Math.Abs(EndPoint.X - StartPoint.X);
			dy = Math.Abs(EndPoint.Y - StartPoint.Y);

			incx = 1;
			if (EndPoint.X < StartPoint.X) incx = -1;
			incy = 1;
			if (EndPoint.Y < StartPoint.Y) incy = -1;
			x = StartPoint.X; y = StartPoint.Y;
			if (dx > dy)
			{
				Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
				e = 2 * dy - dx;
				inc1 = 2 * (dy - dx);
				inc2 = 2 * dy;
				for (i = 0; i < dx; i++)
				{
					if (e >= 0)
					{
						y += incy;
						e += inc1;
					}
					else
						e += inc2;
					x += incx;
					Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
				}

			}
			else
			{
				Utils.Utils.setPixel(x, y, gl, Color, LineWidth);
				e = 2 * dx - dy;
				inc1 = 2 * (dx - dy);
				inc2 = 2 * dx;
				for (i = 0; i < dy; i++)
				{
					if (e >= 0)
					{
						x += incx;
						e += inc1;
					}
					else
						e += inc2;
					y += incy;
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
