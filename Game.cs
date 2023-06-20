using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uss12;
using static System.Formats.Asn1.AsnWriter;


class Game
{
    private Score scoreTracker;

    public Game()
    {
        scoreTracker = new Score();
    }

    public void Start()
    {
        Console.Write("Sisestage oma nimi: ");
        string name = Console.ReadLine();

        Console.Write("Sisestage oma tulemus: ");
        int score = Convert.ToInt32(Console.ReadLine());

        scoreTracker.AddScore(score);
        scoreTracker.SaveScore();

        Console.WriteLine("Mäng on lõppenud. Jätkamiseks vajutage mis tahes klahvi.");
        Console.ReadKey();
    }
}


