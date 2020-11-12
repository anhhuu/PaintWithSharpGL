using LineDraw.Objects;
using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineDraw
{
    public partial class MainForm : Form
    {
        Color userColor;
        short shapeType;
        int lineWidth;

        Point pStart;
        Point pEnd;

        Shape[] drawingObj;

        List<Shape> arrDraw;

        bool isDrawing;


        public MainForm()
        {
            InitializeComponent();
            arrDraw = new List<Shape>();
            userColor = Color.Black;
            lineWidth = 1;
            shapeType = 0;

            drawingObj = new Shape[5];
            drawingObj[0] = new Line(new Point(0, 0), new Point(0, 0), Color.Black, lineWidth);
            drawingObj[1] = new Objects.Rectangle(new Point(0, 0), new Point(0, 0), Color.Black, lineWidth);
            drawingObj[2] = new Circle(new Point(0, 0), new Point(0, 0), Color.Black, lineWidth);
            drawingObj[3] = new Triangle(new Point(0, 0), new Point(0, 0), Color.Black, lineWidth);

            isDrawing = false;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(1, 1, 1, 0);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //gl.LineWidth(lineWidth);
            if (isDrawing)
            {
                drawingObj[shapeType].drawWithOpenGL(gl);
            }

            if (arrDraw.Count > 0)
            {
                foreach (Shape s in arrDraw)
                {
                    s.drawWithOpenGL(gl);
                }
            }
        }

        private void btnColorTable_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                userColor = colorDlg.Color;
                drawingObj[shapeType].color = userColor;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            shapeType = 0;
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            pEnd = pStart;
            drawingObj[shapeType].color = userColor;
            drawingObj[shapeType].lineWidth = lineWidth;
            drawingObj[shapeType].start = pStart;
            drawingObj[shapeType].end = pEnd;
            isDrawing = true;

        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
            isDrawing = false;
            //drawingObj[shapeType].end = pEnd;
            switch (shapeType)
            {
                case 0:
                    Line l = new Line(pStart, pEnd, userColor, lineWidth);
                    arrDraw.Add(l);
                    break;
                case 1:
                    Objects.Rectangle r = new Objects.Rectangle(pStart, pEnd, userColor, lineWidth);
                    arrDraw.Add(r);
                    break;
                case 2:
                    Circle c = new Circle(pStart, pEnd, userColor, lineWidth);
                    arrDraw.Add(c);
                    break;
                case 3:
                    Triangle t = new Triangle(pStart, pEnd, userColor, lineWidth);
                    arrDraw.Add(t);
                    break;
                default:
                    break;
            }

        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
            drawingObj[shapeType].end = pEnd;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            shapeType = 2;
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            shapeType = 1;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            shapeType = 3;
        }

        private void cbLineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbLineWidth.SelectedItem.ToString();
            lineWidth = Int32.Parse(selected);
            drawingObj[shapeType].lineWidth = lineWidth;
        }
    }
}
