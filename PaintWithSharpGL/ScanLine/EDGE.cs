using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.ScanLine
{
    public class Edge
    {
        public double Xi;//The x-coordinate of the lower end of the edge, in the activation linked list (AET), represents the x coordinate of the intersection of the scan line and the edge
        public double ReciSlope;//Is a constant (reciprocal of the slope of the line) (x + dx, y + 1)
        public int Y_Upper;//The y value of the upper vertex of the edge
        public static bool operator <(Edge a, Edge b)//Overloaded relationship
        {
            return (Math.Abs(a.Xi - b.Xi) < 1 ? a.ReciSlope < b.ReciSlope : a.Xi < b.Xi);
        }
        public static bool operator >(Edge a, Edge b)//Overloaded relationship
        {
            return (Math.Abs(a.Xi - b.Xi) < 1 ? a.ReciSlope > b.ReciSlope : a.Xi > b.Xi);
        }
        public static bool operator ==(Edge a, Edge b)//Overload equal to
        {
            return (Math.Abs(a.Xi - b.Xi) < 1 && a.ReciSlope == b.ReciSlope && a.Y_Upper == b.Y_Upper);
        }
        public static bool operator !=(Edge a, Edge b)//Overload not equal to
        {
            return (Math.Abs(a.Xi - b.Xi) > 1 || a.ReciSlope != b.ReciSlope || a.Y_Upper != b.Y_Upper);
        }
    }
}
