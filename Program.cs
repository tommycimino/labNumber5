using System;
using System.Collections.Generic;

namespace lab_5
{
    class Program
    {
        public static int numOfPlayers;
        public static int status; // game status; 0 = live game | 1 = someone won

        static void Main(string[] args)
        {
            status = 0; // sets game as live
            GetUserInput();
            int currentPlayer = 1; // player 1 starts

            do
            {
                currentPlayer = WhosNext(currentPlayer); //figures out whos turn it is

                DrawBoard(currentPlayer);

                HitOrStand(currentPlayer);
                CheckBust();
                CheckGameWinner();

            } while (status.Equals(0));

            if (status.Equals(1))
            {
                Console.WriteLine($"{currentPlayer} Won! They got 21! Press enter to quit.");
                Console.ReadLine();
            }
        }

        static void DrawBoard(int current)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to Blackjack. With {numOfPlayers} player's. ");
            Console.WriteLine("--------+ Blackjack +--------");

            for (int i = 0; i < Player.playerlist.Count; i++)
            {
                Console.WriteLine($"Player {Player.playerlist[i].Number}: {Player.playerlist[i].Cardvalue}");
            }

            Console.WriteLine($"Player {current}'s turn.");
        }

        static void GetUserInput()
        {
            Random r = new Random();
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
                Player p1 = new Player(1, 9);
            }

            if (numOfPlayers.Equals(2))
            {
                Player p1 = new Player(1, r.Next(1, 11));
                Player p2 = new Player(2, r.Next(1, 11));
            }

            if (numOfPlayers.Equals(3))
            {
                Player p1 = new Player(1, r.Next(1, 11));
                Player p2 = new Player(2, r.Next(1, 11));
                Player p3 = new Player(3, r.Next(1, 11));
            }

            if (numOfPlayers.Equals(4))
            {
                Player p1 = new Player(1, r.Next(1, 11));
                Player p2 = new Player(2, r.Next(1, 11));
                Player p3 = new Player(3, r.Next(1, 11));
                Player p4 = new Player(4, r.Next(1, 11));
            }
        }
        static int WhosNext(int current)
        {
            if (current.Equals(1))
            {
                return 2;
            }
            if (current.Equals(2))
            {
                return 3;
            }
            if (current.Equals(3))
            {
                return 4;
            }
            if (current.Equals(4))
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }
        static void HitOrStand(int current)
        {
            Random m = new Random();
            int choice;
            do
            {
                Console.WriteLine("1. Hit 2. Stand");
                Console.Write("Pick: ");
            } while (!int.TryParse(Console.ReadLine(), out choice));

            for (int i = 0; i < Player.playerlist.Count; i++)
            {
                if (choice.Equals(1))
                {
                    if (Player.playerlist[i].Number.Equals(current))
                    {
                        Player.playerlist[i].Cardvalue += m.Next(1, 11);
                        Console.WriteLine("Got hit! Press enter.");
                    }
                }
            }
            if (choice.Equals(2))
            {
                Console.WriteLine("You're standing! Press enter.");
                Console.ReadLine();
            }
            else
            {
                Console.ReadLine();
            }
        }
        static void CheckGameWinner()
        {
            for (int i = 0; i < Player.playerlist.Count; i++)
            {
                if (Player.playerlist[i].Cardvalue.Equals(21))
                {
                    status = 1;
                }
                else if (Player.playerlist.Count == 1)
                {
                    Console.WriteLine("All players lost, you win!");
                    Console.ReadLine();
                }
            }
        }
        static void CheckBust()
        {
            for (int i = 0; i < Player.playerlist.Count; i++)
            {
                if (Player.playerlist[i].Cardvalue > 21)
                {
                    Console.WriteLine($"{Player.playerlist[i].Number} busted!, Value: {Player.playerlist[i].Cardvalue}");
                    Console.WriteLine("They are out of the game!");

                    Player.playerlist.RemoveAt(i);
                    Console.ReadLine();
                }
            }
        }
    }
}
