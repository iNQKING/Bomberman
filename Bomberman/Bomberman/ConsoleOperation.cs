using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class ConsoleOperation
    {
        const int height = 40;
        const int width = 80;
      //RandomItems items = new RandomItems();
      //  Point pozycja;
      //private int score;
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
            WriteAt("╗", 80, 0);
            WriteAt("╚", 0, 40);
            WriteAt("╝", 80, 40);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 40);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 0);
            for (int i = 0; i < height; i++)
            {

                WriteAt("║", 0, 1 + i);
                for (int j = 0; j < width; j++)
                {

                    Console.Write(map.ArrayMap[i, j]);
                }
                WriteAt("║", 80, 1 + i);
            }
        }
        public void DrawBomberman(Bomberman bomberman, Map map)
        {
            foreach (Point point in bomberman.Body)
                map.ArrayMap[point.X, point.Y] = 'o';
        }



        public void ClearMap(Map map)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map.ArrayMap[i, j] = ' ';

        }

    }
}
