﻿using System;
using static OpenTKBasic.Game;

namespace OpenTKBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo");
            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
}
