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
        //the first point of mouse
        Point StartPoint
        {
            get;
            set;
        }

        //the second point of mouse
        Point EndPoint
        {
            get;
            set;
        }

        //color for objects drawing
        Color Color
        {
            get;
            set;
        }

        //line width for objects drawing
        int LineWidth
        {
            get;
            set;
        }

        //draw objects using built-in functions in OpenGL
        void DrawWithOpenGLBuildIn(OpenGL gl);

        //draw objects using theoretical algorithms learned in class 
        void DrawWithTheoreticalAlgorithm(OpenGL gl);

        //return name of object (string)
        string getTypeOfObject();
    }
}
