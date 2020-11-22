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

        public void DrawWithOpenGLBuildIn(OpenGL gl)
        {
            //Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(this.LineWidth);

            //determine the 4 vertices of a rectangle and connect it with lines
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

        public void DrawWithTheoreticalAlgorithm(OpenGL gl)
        {
            //Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //Determine the 4 points of a rectangle and connect it with line drawing theoretical algorithm
            Line l1 = new Line(new Point(StartPoint.X, StartPoint.Y),
                new Point(StartPoint.X, EndPoint.Y), Color, LineWidth);
            l1.DrawWithTheoreticalAlgorithm(gl);

            Line l2 = new Line(new Point(StartPoint.X, StartPoint.Y),
                new Point(EndPoint.X, StartPoint.Y), Color, LineWidth);
            l2.DrawWithTheoreticalAlgorithm(gl);

            Line l3 = new Line(new Point(StartPoint.X, EndPoint.Y),
                new Point(EndPoint.X, EndPoint.Y), Color, LineWidth);
            l3.DrawWithTheoreticalAlgorithm(gl);

            Line l4 = new Line(new Point(EndPoint.X, StartPoint.Y),
                new Point(EndPoint.X, EndPoint.Y), Color, LineWidth);
            l4.DrawWithTheoreticalAlgorithm(gl);

        }
        public string getTypeOfObject()
        {
            return "Rectangle";
        }
    }
}

