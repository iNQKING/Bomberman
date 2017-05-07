using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman
{
    class RandomItems
    {
        static Random rand = new Random();
        Point powerUp;


        public Point RandomApple(Map map)
        {
            do
            {
                powerUp = new Point(rand.Next(0, 19), rand.Next(0, 69));

            } while (map.ArrayMap[powerUp.X, powerUp.Y] != ' ');

            return powerUp;
        }

        //public Point powerUp
        //{
        //    get { return powerUp; }
        //}
    }
}
