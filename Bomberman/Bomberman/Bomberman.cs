using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Bomberman
{
    class Bomberman
    {
        string body;
        Point pozycja;
        bool alive = true;
        int iloscBomb = 3;

        public Bomberman()
        {
            pozycja = new Point(10, 10);
            body = "O";
        }

        public Bomberman(int x, int y)
        {
            pozycja = new Point(x, y);
            body = "O";
        }

        public void setPosition(Point point)
        {
            this.pozycja = point;
        }

        public Point getPosition()
        {
            return this.pozycja;
        }

        public string getBody()
        {
            return body;
        }

        public void setIloscBomb(int ilosc)
        {
            iloscBomb = ilosc;
        }

        public int getIloscBomb()
        {
            return iloscBomb;
        }

        public void plantBomb()
        {
            iloscBomb -= 1;
        }

        public bool isAlive()
        {
            return alive;
        }

        public void killBomberman()
        {
            alive = false;
            
        }

    }
}
