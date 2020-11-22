using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Utils
{
    class Utils
    {
        //set color for pixel
        public static void setPixel(int x, int y, OpenGL gl, Color color, float width) // set pixel at coordinate (x,y) with custom appearance
        {
            gl.PointSize(width);
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
            gl.Flush();
            gl.LineWidth((float)1.0);
        }

        //calculate distance between two point
        public static double getDistanceTowPoint(Point start, Point end)
        {
            double distance = Math.Sqrt(Math.Pow((start.X - end.X), 2) + Math.Pow((start.Y - end.Y), 2));
            return distance;
        }
    }
}
