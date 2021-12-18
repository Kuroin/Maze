using System;

namespace Maze
{
    //Camel Case stilini kullanarak kodladım
    public class Game
    {
        private static readonly ConsoleColor BACKGROUND = ConsoleColor.Black;

        private readonly int left;
        private readonly int top;
        private readonly Maze maze;
        private readonly Player player;
        private readonly Bomba bomb;
        private readonly Bomba2 bomb2;
        public Game(Random random, int left, int top, String templateFileName)
        {
            this.left = left;
            this.top = top;
            this.maze = Maze.Load(left, top, templateFileName);
            this.player = this.maze.createPlayer(random, BACKGROUND);
            this.bomb = this.maze.createBomba(random, BACKGROUND);
            this.bomb2 = this.maze.createBomba2(random, BACKGROUND);
        }

        public void oyna()
        {
            Console.BackgroundColor = BACKGROUND;
            Console.Clear();
            ConsoleKey key;
            do
            {
                this.maze.Show();
                this.player.hareket(this.maze, Direction.NOW);
                this.bomb.bomb(this.maze, Direction.NOW);
                this.bomb2.bomb2(this.maze, Direction.NOW);
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.A:
                        this.player.hareket(this.maze, Direction.LEFT);
                        break;
                    case ConsoleKey.D:
                        this.player.hareket(this.maze, Direction.RIGHT);
                        break;
                    case ConsoleKey.W:
                        this.player.hareket(this.maze, Direction.UP);
                        break;
                    case ConsoleKey.S:
                        this.player.hareket(this.maze, Direction.DOWN);
                        break;
                }
                player.baslangicSec();
                player.bittiMi();
                player.score();
            } while (key != ConsoleKey.Escape);
        }
    }
}
