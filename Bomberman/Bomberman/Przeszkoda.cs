using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Przeszkoda
    {
        Point pozycja;
        string body;

        public Przeszkoda(int x, int y)
        {
            pozycja = new Point(x, y);
            body = "X";
        }

        public Point getPozycja()
        {
            return pozycja;
        }

        public string getBody()
        {
            return body;
        }
    }
}
