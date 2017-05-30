using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Przeszkody
    {
        Point pozycja;
        public Przeszkody(int x, int y)
        {
            pozycja = new Point(x, y);
        }

        public Point getPozycja()
        {
            return pozycja;
        }
    }
}
