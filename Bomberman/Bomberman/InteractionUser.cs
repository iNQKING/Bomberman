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
    enum Direction { Left = 'a', Right = 'd', Up = 'w', Down = 's' }
    Point pozycja;
    Direction currentDirection = Direction.Left;
    ConsoleOperation console = new ConsoleOperation();


    public Point Move(Bomberman bomberman)
    {
        System.Threading.Thread.Sleep(20);


        pozycja = bomberman.GetPosition();

            Point old = pozycja;

        //if (Console.KeyAvailable)
        if(true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == (char)Direction.Up)      // jeśli wcisnęliśmy klawisz 'W'
            {
                    pozycja = new Point(pozycja.X, pozycja.Y - 1);

                    /*
                if (currentDirection != Direction.Down)  // jeśli aktualny kierunek węża jest różny od kierunku w dół
                {
                    pozycja = new Point(pozycja.X, pozycja.Y-1);
                    currentDirection = Direction.Up;
                }
                else                                    // jeśli aktualny kierunek węża to kierunek w dół to wąż pójdzie w górę
                {
                    pozycja = new Point(pozycja.X + 1, pozycja.Y);
                    currentDirection = Direction.Down;
                }
                */
            } else if (key.KeyChar == (char)Direction.Down)        // s
            {/*
                if (currentDirection != Direction.Up)
                {
                    pozycja = new Point(pozycja.X + 1, pozycja.Y);
                    currentDirection = Direction.Down;
                }
                else
                {
                    pozycja = new Point(pozycja.X - 1, pozycja.Y);
                    currentDirection = Direction.Up;
                }
                */

                    pozycja = new Point(pozycja.X, pozycja.Y + 1);
                }


            else if (key.KeyChar == (char)Direction.Left)        // a
            {
                    /*
                if (currentDirection != Direction.Right)
                {
                    pozycja = new Point(pozycja.X, pozycja.Y - 1);
                    currentDirection = Direction.Left;
                }
                else
                {
                    pozycja = new Point(pozycja.X, pozycja.Y + 1);
                    currentDirection = Direction.Right;
                }
                */

                    pozycja = new Point(pozycja.X - 1, pozycja.Y);
                }


            if (key.KeyChar == (char)Direction.Right)       // d
            {
                    /*
                if (currentDirection != Direction.Left)
                {
                    pozycja = new Point(pozycja.X, pozycja.Y + 1);
                    currentDirection = Direction.Right;
                }
                else
                {
                    pozycja = new Point(pozycja.X, pozycja.Y - 1);
                    currentDirection = Direction.Left;
                }*/
                    pozycja = new Point(pozycja.X + 1, pozycja.Y);
                }
        }

        else
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    {
                        pozycja = new Point(pozycja.X - 1, pozycja.Y);
                        break;
                    }
                case Direction.Down:
                    {
                        pozycja = new Point(pozycja.X + 1, pozycja.Y);
                        break;
                    }
                case Direction.Left:
                    {
                        pozycja = new Point(pozycja.X, pozycja.Y - 1);
                        break;
                    }
                case Direction.Right:
                    {
                        pozycja = new Point(pozycja.X, pozycja.Y + 1);
                        break;
                    }
            }
        }

        InsertNewPosition(bomberman);

            return old;
    }
        public void InsertNewPosition(Bomberman bomberman)
        {
            //bomberman.Body.Insert(0, pozycja);
            bomberman.setPosition(pozycja);
        }
}
}