using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineDraw.Objects
{
    interface Shape
    {
        Point start
        {
            get;
            set;
        }

        Point end
        {
            get;
            set;
        }

        Color color
        {
            get;
            set;
        }

        int lineWidth
        {
            get;
            set;
        }

        void drawWithOpenGL(OpenGL gl);
    }
}
