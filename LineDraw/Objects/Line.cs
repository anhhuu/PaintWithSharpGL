using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw.Objects
{
    class Line : Shape
    {
        private Point start;
        private Point end;

        public Point Start { get => start; set => start = value; }
        public Point End { get => end; set => end = value; }

        public void drawWithOpenGL(OpenGL gl, Color color)
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0); // Chọn màu đỏ

            gl.Begin(OpenGL.GL_LINES); // Chọn chế độ vẽ tam giác
            gl.Vertex(start.X, gl.RenderContextProvider.Height - start.Y);
            gl.Vertex(end.X, gl.RenderContextProvider.Height - end.Y);
            gl.End();

            gl.Flush();
        }
    }
}
