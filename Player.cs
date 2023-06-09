using System;
using System.Collections.Generic;
using System.IO;

class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
}

class Game
{
    static void Start()
    {
        List<Player> players = new List<Player>();

        // Загрузка результатов из файла при запуске программы
        LoadPlayersFromFile(players);

        bool playAgain = true;
        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("1. Tulemuste vaatamine");
            Console.WriteLine("2.Mine");
            Console.Write("Valige variant: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "2":
                    PlayGame(players);
                    break;
                case "3":
                    ShowResults(players);
                    break;
                default:
                    Console.WriteLine("Vale valik. Proovige uuesti.");
                    break;
            }
        }

        // Сохранение результатов в файл при выходе из программы
        SavePlayersToFile(players);
    }

    static void PlayGame(List<Player> players)
    {

        // Получение имени игрока
        Console.Write("Sisestage oma nimi: ");
        string name = Console.ReadLine();

        // Получение результата игрока
        Console.Write("Sisestage oma tulemus: ");
        int score = Convert.ToInt32(Console.ReadLine());

        // Создание объекта игрока и добавление его в список игроков
        Player player = new Player { Name = name, Score = score };
        players.Add(player);

        Console.WriteLine("Mäng on lõppenud. Jätkamiseks vajutage mis tahes klahvi.");
        Console.ReadKey();
    }

    static void ShowResults(List<Player> players)
    {
        Console.Clear();
        Console.WriteLine("Tulemused");
        Console.WriteLine("----------");

        // Сортировка игроков по убыванию результатов
        players.Sort((x, y) => y.Score.CompareTo(x.Score));

        foreach (Player player in players)
        {
            Console.WriteLine("Nimi: {0}, Tulemus: {1}", player.Name, player.Score);
        }

        Console.WriteLine("Jätkamiseks vajutage ükskõik millist klahvi.");
        Console.ReadKey();
    }

    static void LoadPlayersFromFile(List<Player> players)
    {
        if (File.Exists("results.txt"))
        {
            using (StreamReader reader = new StreamReader("results.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 2)
                    {
                        string name = data[0];
                        int score = int.Parse(data[1]);
                        Player player = new Player { Name = name, Score = score };
                        players.Add(player);
                    }
                }
            }
        }
    }
    static void SavePlayersToFile(List<Player> players)
    {
        using (StreamWriter writer = new StreamWriter("results.txt"))
        {
            foreach (Player player in players)
            {
                writer.WriteLine("{0},{1}", player.Name, player.Score);
            }
        }
    }
}
    
    
        
  



