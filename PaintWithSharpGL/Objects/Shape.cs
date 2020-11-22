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
        //The first point of mouse
        Point StartPoint
        {
            get;
            set;
        }

        //The second point of mouse
        Point EndPoint
        {
            get;
            set;
        }

        //Color for objects drawing
        Color Color
        {
            get;
            set;
        }

        //Line width for objects drawing
        int LineWidth
        {
            get;
            set;
        }

        //Draw objects using built-in functions in OpenGL
        void DrawWithOpenGL(OpenGL gl);

        //Draw objects using theoretical algorithms learned in class 
        void DrawWithTheoryAlgorithm(OpenGL gl);

        //Return name of object (string)
        string getTypeOfObject();
    }
}
