using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.ScanLine
{
    public class EDGE
    {
        public double xi;//The x-coordinate of the lower end of the edge, in the activation linked list (AET), represents the x coordinate of the intersection of the scan line and the edge
        public double dx;//Is a constant (reciprocal of the slope of the line) (x + dx, y + 1)
        public int ymax;//The y value of the upper vertex of the edge
        public static bool operator <(EDGE a, EDGE b)//Overloaded relationship
        {
            return (Math.Abs(a.xi - b.xi) < 1 ? a.dx < b.dx : a.xi < b.xi);
        }
        public static bool operator >(EDGE a, EDGE b)//Overloaded relationship
        {
            return (Math.Abs(a.xi - b.xi) < 1 ? a.dx > b.dx : a.xi > b.xi);
        }
        public static bool operator ==(EDGE a, EDGE b)//Overload equal to
        {
            return (Math.Abs(a.xi - b.xi) < 1 && a.dx == b.dx && a.ymax == b.ymax);
        }
        public static bool operator !=(EDGE a, EDGE b)//Overload not equal to
        {
            return (Math.Abs(a.xi - b.xi) > 1 || a.dx != b.dx || a.ymax != b.ymax);
        }
    }
}
