using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    //Camel Case stilini kullanarak kodladım
    public class Player
    {
        private const char PLAYERNAME = 'K';

        private readonly ConsoleColor background;
        private int row;
        private int column;
        private int skor = 0;
        private bool carptiMi = false;


        public Player(ConsoleColor background, int row, int column)
        {
            this.background = background;
            this.row = row;
            this.column = column;
        }

        //Oyuncu hareketleri ve skor değişkenleri
        public void hareket(Maze maze, Direction direction)
        {
            this.ciz(this.background, maze.Left, maze.Top);
            switch (direction)
            {
                case Direction.LEFT:
                    if (!maze.IsWall(this.row, this.column - 1))
                    {
                        this.column--;
                        this.skor++;
                    }
                    else
                    {
                        carptiMi = true;
                        this.skor--;
                    }
                    break;
                case Direction.RIGHT:
                    if (!maze.IsWall(this.row, this.column + 1))
                    {
                        this.column++;
                        this.skor++;
                    }
                    else
                    {
                        carptiMi = true;
                        this.skor--;
                    }
                    break;
                case Direction.UP:
                    if (!maze.IsWall(this.row - 1, this.column))
                    {
                        this.row--;
                        this.skor++;
                    }
                    else
                    {
                        carptiMi = true;
                        this.skor--;
                    }
                    break;
                case Direction.DOWN:
                    if (!maze.IsWall(this.row + 1, this.column))
                    {
                        this.row++;              
                    }
                    else
                    {
                        carptiMi = true;
                        this.skor--;
                    }
                    break;
                case Direction.NOW:
                    if (!maze.IsWall(this.row + 1, this.column+1))
                    {
                        this.row=row;
                        this.column=column;
                    }
                    break;
            }
            this.ciz(ConsoleColor.Green, maze.Left, maze.Top);
        }

        private void ciz(ConsoleColor color, int left, int top)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left + this.column, top + this.row);
            Console.Write(PLAYERNAME);
        }
        //Oyuncu sona ulaştığında kazandığını belirten method
        public void bittiMi()
        {
            if((this.row==0) && (this.column==3) || (this.row == 0) && (this.column == 8))
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine();
                Console.WriteLine("KAZANDINIZ!!!!");
                Console.SetCursorPosition(1, 21);
                Console.WriteLine("Oyundan cikmak icin ESC tusuna basiniz!!!");

            }
        }
        //skor tablosu
        public void score()
        {
            Console.SetCursorPosition(1, 17);
            Console.WriteLine("Skor: " + this.skor);
            if(carptiMi==true)
            {
                Console.SetCursorPosition(1, 19);
                Console.WriteLine("Dikkat Duvara Çarptınız!!!");
                carptiMi = false;
            }
            else
            {
                Console.SetCursorPosition(1, 19);
                Console.WriteLine("                           ");
            }
        }
        //Oyuncu  baslangıç noktasına geri döndüğünde yeniden seçim yapabilmesi için
        public void baslangicSec()
        {
            if((this.row == 9) && (this.column == 2) || (this.row == 9) && (this.column == 5) || (this.row == 9) && (this.column == 8))
            {
                Console.SetCursorPosition(1, 22);
                Console.WriteLine("Baslangic noktasini seciniz= ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == 1)
                {
                    row = 9;
                    column = 2;
                }
                if (n == 2)
                {
                    row = 9;
                    column = 5;
                }
                if (n == 3)
                {
                    row = 9;
                    column = 8;
                }
                Console.SetCursorPosition(1, 22);
                Console.WriteLine("                            \n    ");
            }
        }
    }
}
