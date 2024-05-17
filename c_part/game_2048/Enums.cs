﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    public enum Direction
    {
        Left, 
        Up,
        Right,
        Down
    }

    public enum GameStatus
    {
        Idle,
        Win,
        Lose
    }
}
