using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    public class Board
    {
        private Random rand = new Random();
        private int points = 0;

        public int[,] Data { get; protected set; }

        public Board()
        {
            Data = new int[4, 4];
        }

        public bool GenerateNumbers(int number)
        {
            var empty = GetEmptyCells();
            if (empty.Count > 1)
            {
                int pos = empty[rand.Next(empty.Count)];
                Data[pos / 4, pos % 4] = number;
                return true;
            }
            return false;
        }

        public int Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    return MoveUp();
                case Direction.Down:
                    return MoveDown();
                case Direction.Left:
                    return MoveLeft();
                case Direction.Right:
                    return MoveRight();
            }
            return 0;
        }

        private List<int> GetEmptyCells()
        {
            List<int> cells = new List<int>();
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 0; col < Data.GetLength(1); col++)
                {
                    if (Data[row, col] == 0)
                    {
                        cells.Add(row * 4 + col);
                    }
                }
            }
            return cells;
        }

        private int MoveUp()
        {
            for (int col = 0; col < Data.GetLength(1); col++)
            {
                for (int row = 1; row < Data.GetLength(0); row++)
                {
                    int value = Data[row, col];
                    if(value > 0)
                    {
                        for (int i = row - 1; i >= 0; i--)
                        {
                            int prev = Data[i, col];
                            if (prev == 0)
                            {
                                Data[i, col] = value;
                                Data[i + 1, col] = 0;
                            }
                            else if (prev == value)
                            {
                                Data[i, col] = prev + value;
                                Data[i + 1, col] = 0;
                                points += (prev + value);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return points;
        }

        private int MoveDown()
        {
            for (int col = 0; col < Data.GetLength(1); col++)
            {
                for (int row = Data.GetLength(0) - 2; row >= 0 ; row--)
                {
                    int value = Data[row, col];
                    if (value > 0)
                    {
                        for (int i = row + 1; i < Data.GetLength(0); i++)
                        {
                            int prev = Data[i, col];
                            if (prev == 0)
                            {
                                Data[i, col] = value;
                                Data[i - 1, col] = 0;
                            }
                            else if (prev == value)
                            {
                                Data[i, col] = prev + value;
                                Data[i - 1, col] = 0;
                                points += (prev + value);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return points;
        }

        private int MoveLeft()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = 1; col < Data.GetLength(1); col++)
                {
                    int value = Data[row, col];
                    if (value > 0)
                    {
                        for (int i = col - 1; i >= 0; i--)
                        {
                            int prev = Data[row, i];
                            if (prev == 0)
                            {
                                Data[row, i] = value;
                                Data[row, i + 1] = 0;
                            }
                            else if (prev == value)
                            {
                                Data[row, i] = prev + value;
                                Data[row, i + 1] = 0;
                                points += (prev + value);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return points;
        }

        private int MoveRight()
        {
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                for (int col = Data.GetLength(1) - 2; col >= 0; col--)
                {
                    int value = Data[row, col];
                    if (value > 0)
                    {
                        for (int i = col + 1; i < Data.GetLength(1); i++)
                        {
                            int prev = Data[row, i];
                            if (prev == 0)
                            {
                                Data[row, i] = value;
                                Data[row, i - 1] = 0;
                            }
                            else if (prev == value)
                            {
                                Data[row, i] = prev + value;
                                Data[row, i - 1] = 0;
                                points += (prev + value);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return points;
        }

    }
}
