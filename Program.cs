using System;

namespace Maze
{
    //Camel Case stilini kullanarak kodladım
    public class Program
    {
        private static readonly int Yukseklik = 50;
        private static readonly int Genislik = 50;

        private static void Main(string[] args)
        {
            Console.SetWindowSize(Program.Yukseklik, Program.Genislik);
            Console.Title = "Labirent";

            new Game(new Random(), 5, 5, @"..\..\template\template.txt").oyna();
        }
    }
}
