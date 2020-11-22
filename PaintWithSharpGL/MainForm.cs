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
        //user picked color
        private Color UserColor;

        //0: Line
        //1: Circle
        //2: Ellipse
        //3: Triangle
        //4: Rectangle
        //5: Pentagon
        //6: Hexagon
        private short ShapeType;

        //0: OpenGL function
        //1: Theoretical Algorithm
        private short AlgorithmType;

        //user line width picked
        private int LineWidth;

        //the first point of mouse
        private Point StartPoint;
        //the seconds point of mouse
        private Point EndPoint;

        //array storing objects are drawing with mouse
        private Shape[] DrawingObjects;

        //list storing objects have been drawn
        private List<Shape> DrawObjects;

        //status drawing (object choosed)
        private string Status;
        private bool IsStopTimer;

        private bool IsDrawing;

        //height of openGL controll (render contex)
        private int RenderContextProvider_Height;


        public MainForm()
        {
            InitializeComponent();
            DrawObjects = new List<Shape>();
            UserColor = Color.Black;
            LineWidth = 1;
            ShapeType = 0;
            AlgorithmType = 0;
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);

            //init drawing objects
            DrawingObjects = new Shape[7];
            DrawingObjects[0] = new Line(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[1] = new Circle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[2] = new Ellipse(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[3] = new Triangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[4] = new Objects.Rectangle(new Point(0, 0), new Point(0, 0), Color.Black, LineWidth);
            DrawingObjects[5] = new Polygon(new Point(0, 0), new Point(0, 0), Color.Black, 5, LineWidth);
            DrawingObjects[6] = new Polygon(new Point(0, 0), new Point(0, 0), Color.Black, 6, LineWidth);

            Status = "Drawing line";
            lbStatus.Text = Status;
            IsStopTimer = false;
            btnColorTable.BackColor = UserColor;
            IsDrawing = false;

            RenderContextProvider_Height = openGLControl.OpenGL.RenderContextProvider.Height;
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
            //get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            if (IsDrawing)
            {
                if (AlgorithmType == 1)
                {
                    //draw with theoretical algorithm
                    DrawingObjects[ShapeType].DrawWithTheoreticalAlgorithm(gl);
                }
                else
                {
                    //draw with OpenGL build-in function
                    DrawingObjects[ShapeType].DrawWithOpenGLBuildIn(gl);
                }
            }

            if (DrawObjects.Count > 0)
            {
                foreach (Shape shape in DrawObjects)
                {
                    if (IsStopTimer)
                    {
                        if (AlgorithmType == 1)
                        {
                            shape.DrawWithTheoreticalAlgorithm(gl);
                        }
                        else
                        {
                            shape.DrawWithOpenGLBuildIn(gl);
                        }
                    }
                    else
                    {
                        string typeObj = shape.getTypeOfObject();
                        Stopwatch timer = new Stopwatch();
                        
                        //get timer execute algorithm
                        timer.Start();
                        if (AlgorithmType == 1)
                        {
                            shape.DrawWithTheoreticalAlgorithm(gl);
                        }
                        else
                        {
                            shape.DrawWithOpenGLBuildIn(gl);
                        }
                        timer.Stop();
                        
                        if (typeObj == "Line")
                        {
                            lbLineGLTimer.Text = "Line:       " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Circle")
                        {
                            lbCirGLTimer.Text = "Circle:        " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Ellipse")
                        {
                            lbEllipseGLTimer.Text = "Ellipse:      " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Equilateral Triangle")
                        {
                            lbTriGLTimer.Text = "Triangle: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Rectangle")
                        {
                            lbRecGLTimer.Text = "Rectangle: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Equilateral Polygon 5 edges")
                        {
                            lbPenGLTimer.Text = "Pentagon: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                        if (typeObj == "Equilateral Polygon 6 edges")
                        {
                            lbHexGLTimer.Text = "Hexagon: " + timer.Elapsed.TotalMilliseconds.ToString("#,###0.000 'ms'");
                        }
                    }
                }
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartPoint = e.Location;
                StartPoint.Y = RenderContextProvider_Height - StartPoint.Y;

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
                EndPoint.Y = RenderContextProvider_Height - EndPoint.Y;
                IsDrawing = false;

                //drawing real-time when move mouse
                switch (ShapeType)
                {
                    case 0:
                        Line line = new Line(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(line);
                        break;
                    case 1:
                        Circle circle = new Circle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(circle);
                        break;
                    case 2:
                        Ellipse ellipse = new Ellipse(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(ellipse);
                        break;
                    case 3:
                        Triangle triangle = new Triangle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(triangle);
                        break;
                    case 4:
                        Objects.Rectangle rec = new Objects.Rectangle(StartPoint, EndPoint, UserColor, LineWidth);
                        DrawObjects.Add(rec);
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
            //press left mouse button to draw
            if (e.Button == MouseButtons.Left)
            {
                EndPoint = e.Location;
                EndPoint.Y = RenderContextProvider_Height - EndPoint.Y;
                DrawingObjects[ShapeType].EndPoint = EndPoint;
            }
        }

        //set shape type to Line
        private void btnLine_Click(object sender, EventArgs e)
        {
            ShapeType = 0;
            Status = "Line";
            lbStatus.Text = Status;
        }

        //set shape type to Circle
        private void btnCircle_Click(object sender, EventArgs e)
        {
            ShapeType = 1;
            Status = "Circle";
            lbStatus.Text = Status;
        }

        //set shape type to Ellipse
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            ShapeType = 2;
            Status = "Ellipse";
            lbStatus.Text = Status;
        }

        //set shape type to Triangle
        private void btnTriangle_Click(object sender, EventArgs e)
        {
            ShapeType = 3;
            Status = "Equilateral Triangle";
            lbStatus.Text = Status;
        }

        //set shape type to Rectangle
        private void btnRec_Click(object sender, EventArgs e)
        {
            ShapeType = 4;
            Status = "Rectangle";
            lbStatus.Text = Status;
        }

        //set shape type to Pentagon
        private void btnPentagon_Click(object sender, EventArgs e)
        {
            ShapeType = 5;
            Status = "Equilateral Pentagon";
            lbStatus.Text = Status;
        }

        //set shape type to Hexagon
        private void btnHexagon_Click(object sender, EventArgs e)
        {
            ShapeType = 6;
            Status = "Equilateral Hexagon";
            lbStatus.Text = Status;
        }

        //show color dialog
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

        //select line width mode
        private void cbLineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbLineWidth.SelectedItem.ToString();
            LineWidth = Int32.Parse(selected);
            DrawingObjects[ShapeType].LineWidth = LineWidth;
        }

        //stop timer
        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            if (IsStopTimer)
            {
                IsStopTimer = false;
                btnStopTimer.Text = "Stop";
            }
            else
            {
                IsStopTimer = true;
                btnStopTimer.Text = "Start";
            }

        }

        //select algorithm mode (OpenGL or theory)
        private void cbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbAlgorithm.SelectedItem.ToString();
            if (selected == "OpenGL")
            {
                AlgorithmType = 0;
                gbTimer.Text = "OpenGL Algorithm Timer";
            }
            else
            {
                AlgorithmType = 1;
                gbTimer.Text = "Theoretical Algorithm Timer";
            }
        }


        //erase drawn objects
        private void btnClearShape_Click(object sender, EventArgs e)
        {
            //clear drawn objects
            DrawObjects.Clear();
            //set all timer to 0.000 ms
            btnResetTimer_Click(btnResetTimer, e);
        }

        private void btnResetTimer_Click(object sender, EventArgs e)
        {
            //set label timer to 0.000 ms
            lbLineGLTimer.Text = "Line:       0.000 ms";
            lbCirGLTimer.Text = "Circle:        0.000 ms";
            lbEllipseGLTimer.Text = "Ellipse:      0.000 ms";
            lbTriGLTimer.Text = "Triangle: 0.000 ms";
            lbRecGLTimer.Text = "Rectangle: 0.000 ms";
            lbPenGLTimer.Text = "Pentagon: 0.000 ms";
            lbHexGLTimer.Text = "Hexagon: 0.000 ms";
        }
    }
}
