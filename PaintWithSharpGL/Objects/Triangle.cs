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
            //swith model matrix mode

            gl.LoadIdentity();

            gl.PushMatrix();
            //push model matrix with infos below

            //3. transtale EndPoint with O(0,0)->StartPoint vector
            gl.Translate(StartPoint.X, StartPoint.Y, 0.0f);
            //2. rotate EndPoint with the center of rotation is the origin, the rotation angle is 60
            gl.Rotate(60.0, 0.0, 0.0, 1.0);
            //1. transtale EndPoint with StartPoint->O(0,0) vector
            gl.Translate(-StartPoint.X, -StartPoint.Y, 0.0f);
            
            //draw first edge of triangle
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, StartPoint.Y);
            gl.Vertex(EndPoint.X, EndPoint.Y);
            gl.End();

            gl.PopMatrix();
            //pop the model matrix

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
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            double degInRad = 60 * DEGTORAD;

            //C is 3rd vertex, obtained by rotating the EndPoint with the center of rotation as
            //the StartPoint and the rotation angle of 60 degrees
            Point C = new Point();

            //transtale EndPoint with StartPoint->O(0,0) vector, store C
            C.X = EndPoint.X - StartPoint.X;
            C.Y = EndPoint.Y - StartPoint.Y;

            double xC_last = C.X;
            double yC_last = C.Y;

            //rotate EndPoint with the center of rotation is the origin, the rotation angle is 60
            C.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
            C.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

            //transtale EndPoint with O(0,0)->StartPoint vector
            C.X += StartPoint.X;
            C.Y += StartPoint.Y;

            //connect 3 vertices with line using line drawing algorithm
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
