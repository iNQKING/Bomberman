using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class ConsoleOperation
    {
        const int height = 20;
        const int width = 70;
        List<Point> przeszkody;
      //  Point pozycja;
      //private int score;

        public void setPrzeszkody(List<Point> ppp)
        {
            przeszkody = ppp;
        }
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public void DrawMap(Map map)
        {
            WriteAt("╔", 0, 0);
            WriteAt("╗", 71, 0);
            WriteAt("╚", 0, 21);
            WriteAt("╝", 71, 21);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 21);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 0);
            for (int i = 0; i < height; i++)
            {

                WriteAt("║", 0, 1 + i);
                for (int j = 0; j < width; j++)
                {

                    Console.Write(map.ArrayMap[i, j]);
                }
                WriteAt("║", 71, 1 + i);
            }
        }
        public void DrawPrzeszkody()
        {
            //WriteAt("x", 5, 5);
            //WriteAt("x", 10, 10);
            //WriteAt("x", 8, 8);
            //WriteAt("x", 12, 12);
            

            foreach(var p in przeszkody)
            {
                WriteAt("x", p.X, p.Y);
            }
        }
        public void DrawBomberman(Bomberman bomberman, Map map)
        {
            /*
            foreach (Point point in bomberman.Body)
            {
                map.ArrayMap[point.X, point.Y] = 'o';
                WriteAt("o", point.X, point.Y);
            }

    */
            Point bpoint = bomberman.GetPosition();

            WriteAt("o", bpoint.X, bpoint.Y);
        }

        public void clearPoint(Point point)
        {
            WriteAt(" ", point.X, point.Y);
        }


        public void ClearMap(Map map)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map.ArrayMap[i, j] = ' ';

        }

        public void detonate(Bomberman b)
        {
            Point point = b.GetPosition();
           
            WriteAt(" ", point.X+1, point.Y);
            WriteAt(" ", point.X - 1, point.Y);
            WriteAt(" ", point.X, point.Y + 1);
            WriteAt(" ", point.X, point.Y - 1);
            /*
            for(int i=0; i < przeszkody.Capacity; i++)
            {
                if (przeszkody. == point.X + 1 && p.Y == point.Y)
                {
                    przeszkody.Remove(p);
                }
                else if (p.X == point.X - 1 && point.Y == point.Y)
                {
                    przeszkody.Remove(p);
                }
                else if (p.X == point.X && p.Y == point.Y + 1)
                {
                    przeszkody.Remove(p);
                }
                else if (p.X == point.X && p.Y == point.Y - 1)
                {
                    przeszkody.Remove(p);
                }
            }
            */
            foreach(Point p in przeszkody)
            {
                if(p.X == point.X+1 && p.Y == point.Y)
                {
                    przeszkody.Remove(p);
                    break;
                }else if (p.X == point.X - 1 && point.Y == point.Y)
                {
                    przeszkody.Remove(p);
                    break;
                }else if (p.X == point.X && p.Y == point.Y + 1)
                {
                    przeszkody.Remove(p);
                    break;
                }else if(p.X == point.X && p.Y == point.Y - 1)
                {
                    przeszkody.Remove(p);
                    break;
                }
            }

            if(przeszkody.Count == 0)
            {
                Console.Clear();
                WriteAt("KONIEC GRY!", 15, 15);
                System.Threading.Thread.Sleep(100000);
                WriteAt("           ", 15, 35);
                
                //Console.Write("KONIEC Gry!");
            }
        }

    }
}
