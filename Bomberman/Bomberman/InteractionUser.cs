using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Bomberman;
namespace Bomberman

{ 
class InteractionUser
{
        List<Przeszkoda> przeszkody;
        List<Bomba> bomby;
        Bomberman bomberman;
        enum Direction { Left = 'a', Right = 'd', Up = 'w', Down = 's', Bomb = 'x' }

    public void setPrzeszkody(List<Przeszkoda> pp)
    {
        przeszkody = pp;
    }

    public void setBomby(List<Bomba> bomby)
        {
            this.bomby = bomby;
        }

    public void setBomberman(Bomberman bomberman)
        {
            this.bomberman = bomberman;
        }


    public Point Move()
    {

        Point old = bomberman.getPosition();
        Point ret = null;
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (bomberman.isAlive())
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                    break;
                }
            }
            

            if (key.KeyChar == (char)Direction.Up)      // jeśli wcisnęliśmy klawisz 'W'
            {
                if (isPointFree(old.X, old.Y - 1))
                {
                    ret = new Point(old.X, old.Y);
                    bomberman.getPosition().Y -= 1;
                }
            }
            else if (key.KeyChar == (char)Direction.Down)        // s
            {
                if (isPointFree(old.X, old.Y + 1))
                {
                    ret = new Point(old.X, old.Y);
                    bomberman.getPosition().Y += 1;
                }
            }
            else if (key.KeyChar == (char)Direction.Left)        // a
            {
                if (isPointFree(old.X - 1, old.Y))
                {
                    ret = new Point(old.X, old.Y);
                    bomberman.getPosition().X -= 1;
                }
            }
            else if (key.KeyChar == (char)Direction.Right)       // d
            {
                if (isPointFree(old.X + 1, old.Y))
                {
                    ret = new Point(old.X, old.Y);
                    bomberman.getPosition().X += 1;
                }
            }
            else if (key.KeyChar == (char)Direction.Bomb)       //x
            {
                if(bomberman.getIloscBomb() >= 1)
                {
                    bomby.Add(new Bomba(old.X, old.Y));
                    bomberman.plantBomb();
                }
                
            }
            else if(key.KeyChar == 'z')
            {
                if(bomberman.getIloscBomb() >= 1)
                {
                    bomby.Add(new Bomba(old.X, old.Y, 5));
                    bomberman.plantBomb();
                }
                
            }
            return ret;
    }

    public Boolean isPointFree(int x,int y)
        {
            Boolean isPointFree = true;
            foreach(Przeszkoda p in przeszkody)
            {
                if (p.getPozycja().X == x && p.getPozycja().Y == y)
                {
                    isPointFree = false;
                    break;
                }
            }

            if (x > 70 || x < 1)
                isPointFree = false;

            if (y > 20 || y < 1)
                isPointFree = false;

            return isPointFree;
        }
        
}
}