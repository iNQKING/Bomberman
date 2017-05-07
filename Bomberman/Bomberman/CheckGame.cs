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
        Point head;


        public bool CrashWall(Bomberman bomberman)
        {
            head = bomberman.GetPosition();

            if (head.X < 0 || head.X > 19)
            {
                gameOver = true;
                return gameOver;
            }

            if (head.Y < 0 || head.Y > 69)
            {
                gameOver = true;
                return gameOver;
            }

            return gameOver;
        }



        public bool CrashBody(Bomberman bomberman, Map map)
        {
            head = bomberman.GetPosition();

            if (map.ArrayMap[head.X, head.Y] != ' ' && map.ArrayMap[head.X, head.Y] != '*')
            {
                gameOver = true;
                return gameOver;
            }

            return gameOver;
        }
    }
}

