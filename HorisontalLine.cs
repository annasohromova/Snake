using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uss
{
    class HorisontalLine
    {
        List<Point> pList;
        public HorisontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for(int x = xLeft; x <= xRight; x++) 
            {
                

            }
        }

        public void Drow()
        {
            foreach(Point p in pList) 
            {
                p.Draw();
            }

        }
    }
}
