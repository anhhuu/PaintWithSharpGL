using Paint.Objects;
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

namespace Paint
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

        private string Status;

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

            DrawingObjects = new Shape[7];
            DrawingObjects[0] = new Line(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[1] = new Objects.Rectangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[2] = new Circle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[3] = new Ellipse(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[4] = new Triangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[5] = new Polygon(new Point(0, 0), new Point(0, 0), Color.Black, 5, LineWidth);
            DrawingObjects[6] = new Polygon(new Point(0, 0), new Point(0, 0), Color.Black, 6, LineWidth);

            Status = "Status: Drawing line";
            lbStatus.Text = Status;

            btnColorTable.BackColor = UserColor;
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
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    shape.DrawWithOpenGL(gl);
                    timer.Stop();
                    Console.WriteLine("Time Taken: " + timer.Elapsed.TotalMilliseconds.ToString("#,##0.00 'milliseconds'"));
                }
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
            if (e.Button == MouseButtons.Left)
            {
                EndPoint = e.Location;
                IsDrawing = false;
                //drawingObj[shapeType].end = pEnd;
                switch (ShapeType)
                {
                    case 0:
                        Line line = new Line(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(line);
                        break;
                    case 1:
                        Objects.Rectangle rec = new Objects.Rectangle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(rec);
                        break;
                    case 2:
                        Circle circle = new Circle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(circle);
                        break;
                    case 3:
                        Ellipse ellipse = new Ellipse(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(ellipse);
                        break;
                    case 4:
                        Triangle triangle = new Triangle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(triangle);
                        break;
                    case 5:
                        Polygon pentagon = new Polygon(StartPoint, EndPoint, UserColor, 5, LineWidth);
                        DrawObjects.Add(pentagon);
                        break;
                    case 6:
                        Polygon hexagon = new Polygon(StartPoint, EndPoint, UserColor, 6, LineWidth);
                        DrawObjects.Add(hexagon);
                        break;
                    default:
                        break;
                }
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
            Status = "Status: Drawing line";
            lbStatus.Text = Status;
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            ShapeType = 1;
            Status = "Status: Drawing rectangle";
            lbStatus.Text = Status;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            ShapeType = 2;
            Status = "Status: Drawing circle";
            lbStatus.Text = Status;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            ShapeType = 3;
            Status = "Status: Drawing ellipse";
            lbStatus.Text = Status;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            ShapeType = 4;
            Status = "Status: Drawing equilateral triangle";
            lbStatus.Text = Status;
        }

        private void btnPentagon_Click(object sender, EventArgs e)
        {
            ShapeType = 5;
            Status = "Status: Drawing equilateral pentagon";
            lbStatus.Text = Status;
        }

        private void btnHexagon_Click(object sender, EventArgs e)
        {
            ShapeType = 6;
            Status = "Status: Drawing equilateral hexagon";
            lbStatus.Text = Status;
        }

        private void btnColorTable_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                UserColor = colorDlg.Color;
                DrawingObjects[ShapeType].Color = UserColor;
                lbStatus.Text = Status;
                btnColorTable.BackColor = UserColor;
            }
        }

        private void cbLineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbLineWidth.SelectedItem.ToString();
            LineWidth = Int32.Parse(selected);
            DrawingObjects[ShapeType].LineWidth = LineWidth;
        }

        void setPixel(int x, int y, OpenGL gl)
        {
            gl.Color(0.0, 0.0, 0.0); //Set pixel to black  
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y); //Set pixel coordinates 
            gl.End();
        }
    }
}
