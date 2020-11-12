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
        private Color UserColor;
        private short ShapeType;
        private int LineWidth;

        private Point StartPoint;
        private Point EndPoint;

        private Shape[] DrawingObjects;

        private List<Shape> DrawObjects;

        private bool IsDrawing;


        public MainForm()
        {
            InitializeComponent();
            DrawObjects = new List<Shape>();
            UserColor = Color.Black;
            LineWidth = 1;
            ShapeType = 0;

            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);

            DrawingObjects = new Shape[5];
            DrawingObjects[0] = new Line(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[1] = new Objects.Rectangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[2] = new Circle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[3] = new Triangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);

            IsDrawing = false;
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
            if (IsDrawing)
            {
                DrawingObjects[ShapeType].DrawWithOpenGL(gl);
            }

            if (DrawObjects.Count > 0)
            {
                foreach (Shape shape in DrawObjects)
                {
                    shape.DrawWithOpenGL(gl);
                }
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                StartPoint = e.Location;
                EndPoint = StartPoint;
                DrawingObjects[ShapeType].Color = UserColor;
                DrawingObjects[ShapeType].LineWidth = LineWidth;
                DrawingObjects[ShapeType].StartPoint = StartPoint;
                DrawingObjects[ShapeType].EndPoint = EndPoint;
                IsDrawing = true;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            EndPoint = e.Location;
            IsDrawing = false;
            //drawingObj[shapeType].end = pEnd;
            switch (ShapeType)
            {
                case 0:
                    Line l = new Line(StartPoint, EndPoint, UserColor, LineWidth);
                    DrawObjects.Add(l);
                    break;
                case 1:
                    Objects.Rectangle r = new Objects.Rectangle(StartPoint, EndPoint, UserColor, LineWidth);
                    DrawObjects.Add(r);
                    break;
                case 2:
                    Circle c = new Circle(StartPoint, EndPoint, UserColor, LineWidth);
                    DrawObjects.Add(c);
                    break;
                case 3:
                    Triangle t = new Triangle(StartPoint, EndPoint, UserColor, LineWidth);
                    DrawObjects.Add(t);
                    break;
                default:
                    break;
            }

        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EndPoint = e.Location;
                DrawingObjects[ShapeType].EndPoint = EndPoint;
            }
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            ShapeType = 0;
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            ShapeType = 1;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            ShapeType = 2;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            ShapeType = 3;
        }
        private void btnColorTable_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                UserColor = colorDlg.Color;
                DrawingObjects[ShapeType].Color = UserColor;
            }
        }

        private void cbLineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbLineWidth.SelectedItem.ToString();
            LineWidth = Int32.Parse(selected);
            DrawingObjects[ShapeType].LineWidth = LineWidth;
        }
    }
}
