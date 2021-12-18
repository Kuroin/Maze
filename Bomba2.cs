using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    //Camel Case stilini kullanarak kodladım
    public class Bomba2
    {
        private const char BOMBA2 = '2';

        private readonly ConsoleColor background;
        private int row;
        private int column;


        public Bomba2(ConsoleColor background, int row, int column)
        {
            this.background = background;
            this.row = row;
            this.column = column;
        }
        public void bomb2(Maze maze, Direction direction)
        {
            this.bombaCiz2(this.background, maze.Left, maze.Top);
            switch (direction)
            {
                case Direction.NOW:
                    if (!maze.IsWall(this.row + 1, this.column + 1))
                    {
                        this.row = row;
                        this.column = column;
                    }
                    break;
            }
            this.bombaCiz2(ConsoleColor.Blue, maze.Left, maze.Top);
        }
        private void bombaCiz2(ConsoleColor color, int left, int top)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left + this.column, top + this.row);
            Console.Write(BOMBA2);
        }
    }
}
