using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw.Objects
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
            //gl.Begin(OpenGL.GL_QUADS);
            //gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            //gl.Vertex(end.X, gl.RenderContextProvider.Height - start.Y);
            //gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            //gl.Vertex(start.X, gl.RenderContextProvider.Height - end.Y);
            //gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(StartPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - StartPoint.Y);
            gl.Vertex(EndPoint.X, gl.RenderContextProvider.Height - EndPoint.Y);
            gl.End();

            gl.Flush();
        }
    }
}

