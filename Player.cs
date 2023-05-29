using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Snake
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player()
        {
            Name = string.Empty;
            Score = 0;
        }

        public void SetName()
        {
            Console.WriteLine("Введите ваше имя:");
            Name = Console.ReadLine();
        }

        public void IncreaseScore(int points)
        {
            Score += points;
        }

        public void UpdateResult()
        {
            string result = $"{Name}: {Score}";
            File.AppendAllText("results.txt", result + Environment.NewLine);
        }
    }
}

