using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Triangle : Shape
    {
        private const double DEGTORAD = 3.14159 / 180;
        public Triangle(Point start, Point end, Color color, int lineWidth)
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

            //SOLUTION 1: Calculate the C point based on the affine transforms learned in class.

            /*
            double degInRad = 60 * DEGTORAD;
            Point C = new Point();
            C.X = EndPoint.X - StartPoint.X;
            C.Y = EndPoint.Y - StartPoint.Y;

            double xC_last = C.X;
            double yC_last = C.Y;

            C.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
            C.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

            C.X += StartPoint.X;
            C.Y += StartPoint.Y;

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(C.X, C.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(C.X, C.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();
            
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();
            */

            //SOLUTION 2: Calculate the C point based on the affine transforms in OpenGL.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            //Có 3 loại ma trận trong OpenGL, Projection (xử lý phép chiếu), Model (phép biến đổi affine), View,
            //dòng trên xác định với OpenGL mình dùng ma trận model

            gl.LoadIdentity();

            gl.PushMatrix();
            //Đẩy ma trận model với những thông số ở dưới
            gl.Translate(StartPoint.X, StartPoint.Y, 0.0f);
            gl.Rotate(60.0, 0.0, 0.0, 1.0);
            gl.Translate(-StartPoint.X, -StartPoint.Y, 0.0f);
            //Các phép biến đổi sẽ thực hiện ngược từ dưới lên
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();
            //Các đối tượng được vẽ trong đoạn Begin End sẽ chịu ảnh hưởng bới những phép biến đổi affine ở trên

            gl.PopMatrix();
            //Dùng xong ma trận Model, trả thiết lập về cho OpenGL, tránh mọi đối tượng khác đều bị ảnh hưởng

            gl.PushMatrix();
            gl.Translate(EndPoint.X, EndPoint.Y, 0.0f);
            gl.Rotate(-60.0, 0.0, 0.0, 1.0);
            gl.Translate(-EndPoint.X, -EndPoint.Y, 0.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();
            gl.PopMatrix();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
            double degInRad = 60 * DEGTORAD;
            Point C = new Point();
            C.X = EndPoint.X - StartPoint.X;
            C.Y = EndPoint.Y - StartPoint.Y;

            double xC_last = C.X;
            double yC_last = C.Y;

            C.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
            C.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

            C.X += StartPoint.X;
            C.Y += StartPoint.Y;

            Line l1 = new Line(StartPoint, C, Color, LineWidth);
            l1.DrawWithTheoryAlgorithm(gl);

            Line l2 = new Line(C, EndPoint, Color, LineWidth);
            l2.DrawWithTheoryAlgorithm(gl);

            Line l3 = new Line(EndPoint, StartPoint, Color, LineWidth);
            l3.DrawWithTheoryAlgorithm(gl);
        }

        public string getTypeOfObject()
        {
            return "Equilateral Triangle";
        }
    }
}
