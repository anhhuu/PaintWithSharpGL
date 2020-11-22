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
            Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
        }

        public Point StartPoint
        {
            get { return CenterPoint; }
            set
            {
                CenterPoint = value;
                Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
            }
        }
        public Point EndPoint
        {
            get { return BorderPoint; }
            set
            {
                BorderPoint = value;
                Radius = Utils.Utils.calcDistance(CenterPoint, BorderPoint);
            }
        }

        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public void DrawWithOpenGL(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            gl.Begin(OpenGL.GL_LINE_LOOP);
            int angle = 360 / Edge;

            for (int i = 0; i <= 360; i += angle)
            {
                double degInRad = i * DEGTORAD;
                Point A = new Point(CenterPoint.X, CenterPoint.Y);
                Point B = new Point(BorderPoint.X, BorderPoint.Y);
                Point D = new Point();
                D.X = B.X - A.X;
                D.Y = B.Y - A.Y;

                double xC_last = D.X;
                double yC_last = D.Y;

                D.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
                D.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

                D.X += A.X;
                D.Y += A.Y;
                gl.Vertex(D.X, D.Y);
            }

            gl.End();

            gl.Flush();
        }

        public void DrawWithTheoryAlgorithm(OpenGL gl)
        {
            gl.Color(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0, 0);
            gl.LineWidth(LineWidth);

            Point[] points = new Point[Edge];
            int angle = 360 / Edge;

            for (int i = 0, j = 0; i < 360; i += angle, j++)
            {
                double degInRad = i * DEGTORAD;
                
                Point borderPointN = new Point();
                borderPointN.X = BorderPoint.X - CenterPoint.X;
                borderPointN.Y = BorderPoint.Y - CenterPoint.Y;

                double xC_last = borderPointN.X;
                double yC_last = borderPointN.Y;

                borderPointN.X = (int)(xC_last * Math.Cos(degInRad) - yC_last * Math.Sin(degInRad));
                borderPointN.Y = (int)(xC_last * Math.Sin(degInRad) + yC_last * Math.Cos(degInRad));

                borderPointN.X += CenterPoint.X;
                borderPointN.Y += CenterPoint.Y;

                points[j] = new Point(borderPointN.X, borderPointN.Y);
            }
            
            for(int i = 0, j = 1; i < points.Length; i++, j++)
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
