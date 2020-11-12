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
        short shShape;

        Point pStart;
        Point pEnd;

        List<Shape> arrDraw;

        bool isDrawing;


        public MainForm()
        {
            InitializeComponent();
            arrDraw = new List<Shape>();
            userColor = Color.Black;
            shShape = 0;

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

            if (isDrawing)
            {
                gl.Color(userColor.R / 255.0, userColor.G / 255.0, userColor.B / 255.0, 0); // Chọn màu đỏ

                gl.Begin(OpenGL.GL_LINES); // Chọn chế độ vẽ tam giác
                gl.Vertex(pStart.X, gl.RenderContextProvider.Height - pStart.Y);
                gl.Vertex(pEnd.X, gl.RenderContextProvider.Height - pEnd.Y);
                gl.End();

                gl.Flush();
            }

            if (arrDraw.Count > 0)
            {
               foreach(Shape s in arrDraw)
                {
                    //s.drawWithOpenGL(gl, userColor);
                }
            }
        }

        private void btnColorTable_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                userColor = colorDlg.Color;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            shShape = 0;
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            pStart = e.Location;
            pEnd = pStart;
            isDrawing = true;

        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
            isDrawing = false;

            Line l = new Line();
            l.Start = pStart;
            l.End = pEnd;

            arrDraw.Add(l);
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            //if(e.Button == MouseButtons.Right)
            //{
            pEnd = e.Location;
            //}
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LOL");
        }
    }
}
