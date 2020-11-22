using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Objects
{
    class Polygon : Shape
    {
        private double Radius;
        private const double DEGTORAD = 3.14159 / 180;
        protected int Edge;

        private Point CenterPoint;
        private Point BorderPoint;

        public Polygon(Point start, Point end, Color color, int edge, int lineWidth)
        {
            this.CenterPoint = start;
            this.BorderPoint = end;
            this.Color = color;
            this.LineWidth = lineWidth;
            this.Edge = edge;
            Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = Utils.Utils.getDistanceTowPoint(CenterPoint, BorderPoint);
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
			//Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            //use the idea of ​​drawing a circle, with the arcs divided by the number of edges of the polygon
            gl.Begin(OpenGL.GL_LINE_LOOP);

            //each arc have circular measure is 360/num of edges
            int angle = 360 / Edge;

            for (int i = 0; i <= 360; i += angle)
            {
                double degInRad = i * DEGTORAD;

                //translate center point to (0,0)
                Point vertexN = new Point();
                vertexN.X = BorderPoint.X - CenterPoint.X;
                vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                //save the vertex last
                double vertexX_last = vertexN.X;
                double vertexY_last = vertexN.Y;

                //rotate vertex with increase agle
                vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                //translate center point to center point started
                vertexN.X += CenterPoint.X;
                vertexN.Y += CenterPoint.Y;
                gl.Vertex(vertexN.X, vertexN.Y);
            }

            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
			//Set color, line width
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            Point[] points = new Point[Edge];
            int angle = 360 / Edge;

            for (int i = 0, j = 0; i < 360; i += angle, j++)
            {
                double degInRad = i * DEGTORAD;
                
                Point vertexN = new Point();
                vertexN.X = BorderPoint.X - CenterPoint.X;
                vertexN.Y = BorderPoint.Y - CenterPoint.Y;

                double vertexX_last = vertexN.X;
                double vertexY_last = vertexN.Y;

                vertexN.X = (int)(vertexX_last * Math.Cos(degInRad) - vertexY_last * Math.Sin(degInRad));
                vertexN.Y = (int)(vertexX_last * Math.Sin(degInRad) + vertexY_last * Math.Cos(degInRad));

                vertexN.X += CenterPoint.X;
                vertexN.Y += CenterPoint.Y;

                //save vertex of polygon to draw with line drawing theoretical algorithm
                points[j] = new Point(vertexN.X, vertexN.Y);
            }
            
            //loop and draw each edge with line drawing theoretical algorithm
            for (int i = 0, j = 1; i < points.Length; i++, j++)
            {
                if(j == points.Length)
                {
                    j = 0;
                }

                Line l = new Line(points[i], points[j], Color, LineWidth);

                l.DrawWithTheoryAlgorithm(gl);
            }
        }
        public string getTypeOfObject()
        {
            return "Equilateral Polygon " + Edge + " edges";
        }
    }
}
