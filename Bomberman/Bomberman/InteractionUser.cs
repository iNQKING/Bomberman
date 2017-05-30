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
    enum Direction { Left = 'a', Right = 'd', Up = 'w', Down = 's', Bomb='x'}
    Point pozycja;
    Direction currentDirection = Direction.Left;
    ConsoleOperation console = new ConsoleOperation();
    List<Point> przeszkody;

    public void setPrzeszkody(List<Point> pp)
        {
            przeszkody = pp;
        }


    public Point Move(Bomberman bomberman)
    {
        System.Threading.Thread.Sleep(20);


        pozycja = bomberman.GetPosition();

        Point old = pozycja;

   
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == (char)Direction.Up)      // jeśli wcisnęliśmy klawisz 'W'
            {
                    pozycja = new Point(pozycja.X, pozycja.Y - 1);

             
            } else if (key.KeyChar == (char)Direction.Down)        // s
            {

                    pozycja = new Point(pozycja.X, pozycja.Y + 1);
                }


            else if (key.KeyChar == (char)Direction.Left)        // a
            {

                    pozycja = new Point(pozycja.X - 1, pozycja.Y);
                }


            else if (key.KeyChar == (char)Direction.Right)       // d
            {
                 
                    pozycja = new Point(pozycja.X + 1, pozycja.Y);
            }

            else if (key.KeyChar == (char)Direction.Bomb)
            {
                return new Point(999, 999);
            }


            foreach(Point p in przeszkody)
            {
                if(p.X == pozycja.X && p.Y == pozycja.Y)
                {
                    pozycja = old;
                }
            }
       

        InsertNewPosition(bomberman);

         return old;
    }
        public void InsertNewPosition(Bomberman bomberman)
        {
     ;
            bomberman.setPosition(pozycja);
        }
}
}