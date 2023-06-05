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
            Console.WriteLine("Змейка");
            Console.WriteLine("-------");
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Просмотреть результаты");
            Console.WriteLine("3. Выйти");
            Console.Write("Выберите опцию: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PlayGame(players);
                    break;
                case "2":
                    ShowResults(players);
                    break;
                case "3":
                    playAgain = false;
                    break;
                default:
                    Console.WriteLine("Неправильный выбор. Попробуйте ещё раз.");
                    break;
            }
        }

        // Сохранение результатов в файл при выходе из программы
        SavePlayersToFile(players);
    }

    static void PlayGame(List<Player> players)
    {
        Console.Clear();
        Console.WriteLine("Игра началась!");
        // Логика игры Змейка

        // Получение имени игрока
        Console.Write("Введите ваше имя: ");
        string name = Console.ReadLine();

        // Получение результата игрока
        Console.Write("Введите ваш результат: ");
        int score = Convert.ToInt32(Console.ReadLine());

        // Создание объекта игрока и добавление его в список игроков
        Player player = new Player { Name = name, Score = score };
        players.Add(player);

        Console.WriteLine("Игра окончена. Нажмите любую клавишу, чтобы продолжить.");
        Console.ReadKey();
    }

    static void ShowResults(List<Player> players)
    {
        Console.Clear();
        Console.WriteLine("Результаты");
        Console.WriteLine("----------");

        // Сортировка игроков по убыванию результатов
        players.Sort((x, y) => y.Score.CompareTo(x.Score));

        foreach (Player player in players)
        {
            Console.WriteLine("Имя: {0}, Результат: {1}", player.Name, player.Score);
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
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


