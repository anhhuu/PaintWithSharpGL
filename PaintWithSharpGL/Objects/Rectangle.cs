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
            this.start = start;
            this.end = end;
            this.color = color;
            this.lineWidth = lineWidth;
        }

        public Point start { get; set; }
        public Point end { get; set; }
        public Color color { get; set; }
        public int lineWidth { get; set; }

        public void drawWithOpenGL(OpenGL gl)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0); 
            gl.LineWidth(this.lineWidth);
            //gl.Begin(OpenGL.GL_QUADS);
            //gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            //gl.Vertex(end.X, gl.RenderContextProvider.Height - start.Y);
            //gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            //gl.Vertex(start.X, gl.RenderContextProvider.Height - end.Y);
            //gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - start.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(start.X, gl.RenderContextProvider.Height - end.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Begin(OpenGL.GL_LINES); 
            gl.Vertex(end.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Flush();
        }
    }
}

