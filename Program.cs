using System;
using System.Collections.Generic;

namespace lab_5
{
    class Program
    {
        public static int numOfPlayers;
        public static bool nowinner;
        public static int currentPlayer;


        static void Main(string[] args)
        {
            GetUserInput();

            Console.WriteLine($"Welcome to Blackjack. With {numOfPlayers} player's. ");
            Console.WriteLine("Dealing...");

            GameLogic();
        }

        static void GameLogic()
        {
            Console.Clear();
            Console.WriteLine("--------+ Blackjack +--------");
            
            do
            {
                for (int i = 0; i < Player.playerlist.Count; i++)
                {
                    Console.WriteLine($"Player {Player.playerlist[i].Number}: {Player.playerlist[i].Cardvalue}");
                }

            } while (nowinner == true);
        }

        static void GetUserInput()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to blackjack.");
                Console.Write("How many players? (Only 1-4): ");

            } while (!int.TryParse(Console.ReadLine(), out numOfPlayers));

            if (numOfPlayers > 4)
            {
                GetUserInput();
            }

            if (numOfPlayers.Equals(1))
            {
                Console.WriteLine("You will be playing by yourself.");
            }

            if (numOfPlayers.Equals(2))
            {
                Player p1 = new Player(1);
                Player p2 = new Player(2);
            }

            if (numOfPlayers.Equals(3))
            {
                Player p1 = new Player(1);
                Player p2 = new Player(2);
                Player p3 = new Player(3);
            }

            if (numOfPlayers.Equals(4))
            {
                Player p1 = new Player(1);
                Player p2 = new Player(2);
                Player p3 = new Player(3);
                Player p4 = new Player(4);
            }
        }
    }
}
