using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class CheckGame
    {
        private bool gameOver = false;
        Point pozycja;


        public bool CrashWall(Bomberman bomberman)
        {
            pozycja = bomberman.GetPosition();

            if (pozycja.X < 1 || pozycja.X > 70)
            {
                gameOver = true;
                return gameOver;
            }

            if (pozycja.Y < 1 || pozycja.Y > 20)
            {
                gameOver = true;
                return gameOver;
            }

            return gameOver;
        }

        public bool CrashBody(Bomberman bomberman, Map map)
        {
            pozycja = bomberman.GetPosition();

            if (map.ArrayMap[pozycja.X, pozycja.Y] != ' ' && map.ArrayMap[pozycja.X, pozycja.Y] != '*')
            {
                gameOver = true;
                return gameOver;
            }

            return gameOver;
        }
    }
}

