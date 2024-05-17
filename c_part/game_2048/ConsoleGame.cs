using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    public class ConsoleGame
    {
        private Game game;

        public void Start()
        {
            game = new Game();
            game.Board.GenerateNumbers(2);
            game.Board.GenerateNumbers(2);
            DrawBoard();
            while (game.GameStatus == GameStatus.Idle)
            {
                Direction dir = this.GetDirection();
                Console.WriteLine(dir.ToString());
                game.Move(dir);
                DrawBoard();
                Console.WriteLine("");
            }
            Console.WriteLine("You " + game.GameStatus.ToString()+ "!");
        }

        private Direction GetDirection()
        {
            while (true)
            {
                Console.Write("Press Arrow key: ");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        return Direction.Up;
                    case ConsoleKey.DownArrow:
                        return Direction.Down;
                    case ConsoleKey.LeftArrow:
                        return Direction.Left;
                    case ConsoleKey.RightArrow:
                        return Direction.Right;
                    default:
                        Console.WriteLine(" - Wrong Key!");
                        break;
                }
            }
        }

        private void DrawBoard()
        {
            for (int row = 0; row < game.Board.Data.GetLength(0); row++)
            {
                string strRow = "|";
                for (int col = 0; col < game.Board.Data.GetLength(1); col++)
                {
                    int value = game.Board.Data[row, col];
                    string strValue = value.ToString();
                    if (value == 0)
                    {
                        strValue = "    ";
                    }
                    else
                    {
                        while (strValue.Length < 4)
                        {
                            strValue = " " + strValue;
                        }
                    }
                    strRow += (" " + strValue + " |");
                }
                Console.WriteLine(strRow);
            }
            Console.Write("Score: " + game.Points.ToString());
            Console.WriteLine();
        }
    }
}
