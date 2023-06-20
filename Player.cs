using System;
using System.Collections.Generic;
using System.IO;
using uss12;


namespace uss12
{

    class Game
    {

        public void WriteGameAlgas()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("     G A M E  A L G A S", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("   Autor: Anna Sohromova", xOffset + 2, yOffset++);
            WriteText("   Special for TTHK", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Console.ReadLine();
        }

        private void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}



