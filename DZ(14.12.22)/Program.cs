using System.Collections.Generic;
using System.Xml.Linq;

namespace DZ_14._12._22_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //RacingGames racingGames = new RacingGames();
            //racingGames.Game();
            Game game = new Game();
            game.StartGame();

        }
    }

    class RacingGames
    {
        List<Car> cars = new List<Car>();
        delegate void DelegateStartLine();
        delegate void DelegateFinish(Car car);
        event DelegateFinish eventFinish;
        public void Game()
        {
            eventFinish += Finish;
            AddCar();
            DelegateStartLine delegateStartLine = null;
            for (int i = 0; i < cars.Count; i++)
            {
                delegateStartLine += cars[i].StartLine;
            }
            Console.Clear();
            delegateStartLine();
            Thread.Sleep(3000);
            for (int i = 3; i >= 0; i--)
            {
                Console.Clear();
                if(i > 0)
                    Console.WriteLine($"\n\n\n\n\n\t\t\tСТАРТ ЧЕРЕЗ {i}");
                else
                    Console.WriteLine($"\n\n\n\n\n\t\t\tПОГНАЛИ!");
                Thread.Sleep(1000);
            }
            while (true)
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Distance >= Car.maxDistance)
                        eventFinish(cars[i]);
                    else
                        cars[i].Move();
                }
                ShowGame();
                Thread.Sleep(1000);
            }
        }

        void Finish(Car car)
        {
            car.Finish();
        }

        void ShowGame()
        {
            Console.Clear();
            for (int i = 0; i < cars.Count; i++)
            {
                int count = (int)(cars[i].Distance / 10) / 10;
                string str = "";
                for (int j = 0; j < count; j++)
                {
                    str += "=";
                }
                Console.WriteLine(cars[i].Model + " " + str + " " + cars[i].Distance + "m");
            }
        }

        void AddCar()
        {
            string str = null;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить в гонку легковой автомобиль\n2. Добавить в гонку спортивный автомобиль\n3. Добавить в гонку грузовой автомобиль\n4. Добавить в гонку автобус\n0. Начать гонку");
                str = Console.ReadLine();
                
                if (str == "1")
                {
                    Console.WriteLine("Введите имя авто и максимальную скорость");
                    cars.Add(new PassengerCar(Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
                }
                else if (str == "2")
                {
                    Console.WriteLine("Введите имя авто и максимальную скорость");
                    cars.Add(new SportCar(Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
                }
                else if (str == "3")
                {
                    Console.WriteLine("Введите имя авто и максимальную скорость");
                    cars.Add(new Truck(Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
                }
                else if (str == "4")
                {
                    Console.WriteLine("Введите имя авто и максимальную скорость");
                    cars.Add(new Bus(Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
                }
                else if(str == "0")
                {
                    if (cars.Count < 2)
                    {
                        Console.WriteLine("В гонке не может участвовать меньше двух машин, добавьте еще машину!");
                        Console.ReadKey();
                    }
                    else
                        break;
                }
            }
        }
    }
    abstract class Car
    {
        protected string model;
        protected int maxSpeed;
        protected float distance;
        public static int maxDistance = 3000;

        protected Car(string model, int maxSpeed)
        {
            this.model = model;
            this.maxSpeed = maxSpeed;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }
        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        abstract public void Move();
        abstract public void StartLine();
        abstract public void Finish();
    }
    class PassengerCar : Car
    {
        public PassengerCar(string model, int maxSpeed) : base(model, maxSpeed)
        { }
        public override void Move()
        {
            Random rnd = new Random();
            distance += rnd.Next(maxSpeed - 20, maxSpeed);
            if (distance > maxDistance) distance = maxDistance;
        }
        public override void StartLine()
        {
            Console.WriteLine($"Машина {model} вышла на старт");
        }
        public override void Finish()
        {
            Console.WriteLine("Гонка закончилась, выиграла машина - " + model);
            Console.ReadKey();
        }
    }
    class SportCar : Car
    {
        public SportCar(string model, int maxSpeed) : base(model, maxSpeed)
        { }
        public override void Move()
        {
            Random rnd = new Random();
            distance += rnd.Next(maxSpeed - 15, maxSpeed);
            if(distance > maxDistance) distance = maxDistance;
        }
        public override void StartLine()
        {
            Console.WriteLine($"Машина {model} вышла на старт");
        }
        public override void Finish()
        {
            Console.WriteLine("Гонка закончилась, выиграла машина - " + model);
            Console.ReadKey();
        }
    }
    class Truck : Car
    {
        public Truck(string model, int maxSpeed) : base(model, maxSpeed)
        { }
        public override void Move()
        {
            Random rnd = new Random();
            distance += rnd.Next(maxSpeed - 25, maxSpeed);
            if (distance > maxDistance) distance = maxDistance;
        }
        public override void StartLine()
        {
            Console.WriteLine($"Машина {model} вышла на старт");
        }
        public override void Finish()
        {
            Console.WriteLine("Гонка закончилась, выиграла машина - " + model);
            Console.ReadKey();
        }
    }
    class Bus : Car
    {
        public Bus(string model, int maxSpeed) : base(model, maxSpeed)
        { }
        public override void Move()
        {
            Random rnd = new Random();
            distance += rnd.Next(maxSpeed - 30, maxSpeed);
            if (distance > maxDistance) distance = maxDistance;
        }
        public override void StartLine()
        {
            Console.WriteLine($"Машина {model} вышла на старт");
        }
        public override void Finish()
        {
            Console.WriteLine("Гонка закончилась, выиграла машина - " + model);
            Console.ReadKey();
        }
    }







    public enum Suit
    {
        Club = 1,
        Diamond = 2,
        Heart = 3,
        Spades = 4,
    }

    public enum CardNumber
    {
        Six = 1,
        Seven = 2,
        Eight = 3,
        Nine = 4,
        Ten = 5,
        Jack = 6,
        Queen = 7,
        King = 8,
        Ace = 9
    }

    class Game
    {
        List<Player> players = new List<Player>();
        List<Karta> koloda = new List<Karta>();

        void Fill()
        {
            koloda = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 9)
            .Select(c => new Karta()
                {
                    mast = (Suit)s,
                    type = (CardNumber)c
                })
            ).ToList();
        }

        void Shuffle()
        {
            koloda = koloda.OrderBy(c => Guid.NewGuid()).ToList();
        }

        void CreatPlayer()
        {
            int count = 0;
            while (count < 2)
            {
                Console.WriteLine("Введите число игроков");
                count = Convert.ToInt32(Console.ReadLine());
                if (count < 2)
                    Console.WriteLine("Игроков не может быть меньше двух");
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите имя игрока № {i + 1}");
                players.Add(new Player { Name = Console.ReadLine() });
            }
        }

        void ShowKoloda()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(players[i].Name);
                players[i].ShowKarta();
            }
        }

        Karta MaxKarta(List<Karta>k)
        {
            Karta buf = k[0];
            for (int i = 1; i < k.Count; i++)
            {
                if (buf.type < k[i].type) buf = k[i]; 
            }
            return buf;
        }

        public void StartGame()
        {
            Fill();
            Shuffle();
            CreatPlayer();
            for (int i = 0, j = 0; i < koloda.Count - (koloda.Count % players.Count); i++)
            {
                if (j >= players.Count)
                    j = 0;
                players[j++].Karta = koloda[i];
            }
            List<Karta> stol = new List<Karta>();

            while (players.Count > 1)
            {
                ShowKoloda();
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].CountKarta() != 0)
                    {
                        stol.Add(players[i].Karta);
                        Console.WriteLine($"У игрока {players[i].Name} карта: {stol[i].type}/{stol[i].mast}");
                        players[i].DelKarta();
                    }
                }
                int max = stol.LastIndexOf(MaxKarta(stol));
                Console.WriteLine($"Этот круг выиграл игрок {players[max].Name}");
                for (int i = 0; i < stol.Count; i++)
                {
                    players[max].Karta = stol[i];
                }
                stol.Clear();
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].CountKarta() == 0)
                        players.Remove(players[i]);
                }
            }
            Console.WriteLine($"Выиграл игрок {players[0].Name}");
        }
    }

    class Player
    {
        string name;
        List<Karta> karta = new List<Karta>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Karta Karta
        {
            get { return karta[0]; }
            set { karta.Add(value); }
        }
        public int CountKarta()
        {
            return karta.Count;
        }
        public void DelKarta()
        {
            karta.Remove(karta[0]);
        }
        public void ShowKarta()
        {
            foreach(var e in karta)
            {
                Console.WriteLine($"Масть карты {e.mast} Значение карты {e.type}");
            }
        }
    }

    class Karta
    {
        public Suit mast;
        public CardNumber type;
    }

}