using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    class Game
    {
        public Board Board { get; protected set; }
        public GameStatus GameStatus { get; protected set; }
        public int Points { get; protected set; }

        public Game()
        {
            this.Board = new Board();
        }

        public void Move(Direction direction)
        {
            Points = Board.Move(direction);
            if(Points >= 2048)
            {
                GameStatus = GameStatus.Win;
            }
            if(Board.GenerateNumbers(2) == false)
            {
                GameStatus = GameStatus.Lose;
            }
        }

    }
}
