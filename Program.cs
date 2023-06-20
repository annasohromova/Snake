using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using uss12;
using static System.Formats.Asn1.AsnWriter;

namespace uss12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.ForegroundColor = ConsoleColor.Green;

            Game game = new Game();
            game.WriteGameAlgas();
            Console.ReadLine();
            Console.Clear();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            FoodCreator foodCreator2 = new FoodCreator(80, 25, '#');
            Point food2 = foodCreator2.CreateFood();
            food2.Draw();

            FoodCreator speedFoodCreator = new FoodCreator(80, 25, 'S');
            Point speedFood = speedFoodCreator.CreateSpeedFood();
            speedFood.Draw();

            Heli play = new Heli();


            snake.Speed = 100;
            bool speedFoodEaten = false;
            bool food2Eaten = false;
            Score score = new Score();

            score.AddScore(10);
            score.AddScore(5);
            score.AddScore(15);

            score.SaveScore();
            Console.ReadLine();
            _ = play.Natuke_mangida("../../../back.mp3");

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(speedFood))
                {
                    _ = play.Natuke_mangida("../../../eat.wav");
                    speedFood = speedFoodCreator.CreateFood();
                    speedFood.Draw();
                    snake.SpeedUp();
                    speedFoodEaten = true;
                }
                else if (snake.Eat1(food2))
                {
                    _ = play.Natuke_mangida("../../../eat.wav");
                    snake.SpeedUp();
                    food2Eaten = true;
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(snake.Speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                if (snake.Eat(food2))
                {
                    food2 = foodCreator2.CreateFood();
                    food2.Draw();
                }

                if (speedFoodEaten && (food2Eaten || snake.Speed % 100 == 0))
                {
                    speedFoodEaten = false;
                    food2Eaten = false;
                }

                if (food.X == 0 && food.Y == 0)
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }

                if (food2.X == 0 && food2.Y == 0)
                {
                    food2 = foodCreator2.CreateFood();
                    food2.Draw();
                }

                if (speedFood.X == 0 && speedFood.Y == 0)
                {
                    speedFood = speedFoodCreator.CreateFood();
                    speedFood.Draw();
                }
            }

            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("     G A M E  O V E R ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("   Autor: Anna Sohromova", xOffset + 2, yOffset++);
            WriteText("   Special for TTHK", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            Heli over = new Heli();
            _ = over.Natuke_mangida("../../../dead.wav");
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void WriteGameAlgas()
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
        }

        static void WriteText2(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}

