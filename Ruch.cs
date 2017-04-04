using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class InteractionUser
{
    enum Direction { Left = 'a', Right = 'd', Up = 'w', Down = 's' }
    Point pozycja;
    Direction currentDirection = Direction.Left;
    ConsoleOperation console = new ConsoleOperation();


    public void Move(Snake postac)
    {
        System.Threading.Thread.Sleep(20);


        pozycja = postac.GetPosition();
    


        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);


            if (key.KeyChar == (char)Direction.Up)      // jeśli wcisnęliśmy klawisz 'W'
            {
                if (currentDirection != Direction.Down)  // jeśli aktualny kierunek węża jest różny od kierunku w dół
                {
                    pozycja = new Point(pozycja.X - 1, pozycja.Y);
                    currentDirection = Direction.Up;
                }
                else                                    // jeśli aktualny kierunek węża to kierunek w dół to wąż pójdzie w górę
                {
                    pozycja = new Point(pozycja.X + 1, pozycja.Y);
                    currentDirection = Direction.Down;
                }
            }


            if (key.KeyChar == (char)Direction.Down)        // s
            {
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
            }


            if (key.KeyChar == (char)Direction.Left)        // a
            {
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
            }


            if (key.KeyChar == (char)Direction.Right)       // d
            {
                if (currentDirection != Direction.Left)
                {
                    pozycja = new Point(pozycja.X, pozycja.Y + 1);
                    currentDirection = Direction.Right;
                }
                else
                {
                    pozycja = new Point(pozycja.X, pozycja.Y - 1);
                    currentDirection = Direction.Left;
                }
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

        InsertNewPosition(postac);
    }
}