using System;
using System.Collections.Generic;


public class Player
{
    public int Number;
    public int Cardvalue;
    Random random = new Random();
    public static List<Player> playerlist = new List<Player>();    

    public Player(int number)
    {
        Number = number;
        Cardvalue = random.Next(1, 11);

        playerlist.Add(this);
    }
}