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
      //Point head;
        private int score;
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
            WriteAt("╗", 81, 0);
            WriteAt("╚", 0, 41);
            WriteAt("╝", 81, 41);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 41);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 0);
            for (int i = 0; i < height; i++)
            {

                WriteAt("║", 0, 1 + i);
                for (int j = 0; j < width; j++)
                {

                    Console.Write(map.ArrayMap[i, j]);
                }
                WriteAt("║", 81, 1 + i);
            }
        }
    }
}
