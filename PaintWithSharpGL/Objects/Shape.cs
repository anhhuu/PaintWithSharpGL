using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    interface Shape
    {
        Point StartPoint
        {
            get;
            set;
        }

        Point EndPoint
        {
            get;
            set;
        }

        Color Color
        {
            get;
            set;
        }

        int LineWidth
        {
            get;
            set;
        }

        void DrawWithOpenGL(OpenGL gl);
    }
}
