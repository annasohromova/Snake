using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace uss
{
    class Snake
    {
        public Snake(Point tail, int lenght, Direction direction) 
        { 
            pList = new List<Point>();
            for(int i = 0; i < lenght; i++) 
            {
                Point p= new Point( tail );
                p.Move(i, direction);
                pList.Add( p );
            }
        
        }
        internal void Move()
        {
            throw new NotImplementedException();

        }
    }
}
