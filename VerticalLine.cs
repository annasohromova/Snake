using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uss;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
        public virtual void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Устанавливаем цвет
            foreach (Point p in pList)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(p.sym);
            }
            Console.ResetColor(); // Сбрасываем цвет
        }
    }
}
