using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Rectangle : Shape
    {
        public Rectangle(Point start, Point end, Color color, int lineWidth)
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
            gl.LineWidth(this.LineWidth);
          
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(StartPoint.X, EndPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, StartPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(StartPoint.X, EndPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(EndPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();
            
            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
            Line l1 = new Line(new Point(StartPoint.X, StartPoint.Y), 
                new Point(StartPoint.X, EndPoint.Y), Color, LineWidth);

            Line l2 = new Line(new Point(StartPoint.X, StartPoint.Y),
                new Point(EndPoint.X, StartPoint.Y), Color, LineWidth);

            Line l3 = new Line(new Point(StartPoint.X, EndPoint.Y),
                new Point(EndPoint.X, EndPoint.Y), Color, LineWidth);

            Line l4 = new Line(new Point(EndPoint.X, StartPoint.Y),
                new Point(EndPoint.X, EndPoint.Y), Color, LineWidth);

            l1.DrawWithTheoryAlgorithm(gl);
            l2.DrawWithTheoryAlgorithm(gl);
            l3.DrawWithTheoryAlgorithm(gl);
            l4.DrawWithTheoryAlgorithm(gl);
        }
        public string getTypeOfObject()
        {
            return "Rectangle";
        }
    }
}

