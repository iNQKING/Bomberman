using System;
using System.Collections.Generic;
using System.Threading;

namespace Bomberman
{
    class ConsoleOperation
    {
        const int height = 20;
        const int width = 70;

        List<Przeszkoda> przeszkody;
        List<Bomba> bomby;
        Bomberman bomberman;

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

        public void WriteAt(string s, int x, int y, ConsoleColor consoleColor)
        {
            ConsoleColor backup = Console.BackgroundColor;
            Console.BackgroundColor = consoleColor;
            WriteAt(s, x, y);
            Console.BackgroundColor = backup;
        }

        public void DrawMap(Map map)
        {
            WriteAt("╔", 0, 0);
            WriteAt("╗", 71, 0);
            WriteAt("╚", 0, 21);
            WriteAt("╝", 71, 21);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 21);
            WriteAt("══════════════════════════════════════════════════════════════════════", 1, 0);
            WriteAt("Masz bomb: ", 0, 23);
            WriteAt(bomberman.getIloscBomb().ToString(), 11, 23);

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

        public void drawBomby()
        {
            foreach(Bomba b in bomby)
            {
                WriteAt(b.getBody(), b.getPosition().X, b.getPosition().Y);
            }
        }

        public void drawPrzeszkody()
        {
            foreach(var P in przeszkody)
            {
                WriteAt(P.getBody(), P.getPozycja().X, P.getPozycja().Y);
            }
        }
        public void drawBomberman()
        {
            if(bomberman.isAlive())
                WriteAt(bomberman.getBody(), bomberman.getPosition().X, bomberman.getPosition().Y);
        }

        public void clearPoint(Point point)
        {
            bool clearOrNotToClear = true;

            foreach (Bomba b in bomby)
            {
                if (point.X == b.getPosition().X && point.Y == b.getPosition().Y)
                {
                    clearOrNotToClear = false;
                    break;
                }
            }
            if(clearOrNotToClear)
                WriteAt(" ", point.X, point.Y);
        }


        public void ClearMap(Map map)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map.ArrayMap[i, j] = ' ';

        }

        public void detonate(Bomba bomba)
        {

            splash(bomba.getPosition().X, bomba.getPosition().Y, ConsoleColor.Red);
            removePrzeszkody(bomba.getPosition().X, bomba.getPosition().Y);
            killThemAll(bomba.getPosition().X, bomba.getPosition().Y);


            bomby.Remove(bomba);

            Thread.Sleep(500);

            splash(bomba.getPosition().X, bomba.getPosition().Y, ConsoleColor.Black);

            drawBomberman();
            WriteAt(bomberman.getIloscBomb().ToString(), 11, 23);

            if (bomberman.getIloscBomb() == 0 && bomby.Count == 0)
                bomberman.killBomberman();
        }

        public void splash(int x, int y, ConsoleColor color)
        {
            WriteAt(" ", x, y, color);
            WriteAt(" ", (x+1), y, color);
            WriteAt(" ", (x-1), y, color);
            WriteAt(" ", x, (y+1), color);
            WriteAt(" ", x, (y-1), color);
        }

        public void removePrzeszkody(int x, int y)
        {
            for(int i=0; i < przeszkody.Count; i++)
            {
                Przeszkoda p = przeszkody[i];
                if(x == p.getPozycja().X && y == p.getPozycja().Y)
                {
                    przeszkody.Remove(p);
                    i--;
                }else if((x+1) == p.getPozycja().X && y == p.getPozycja().Y)
                {
                    przeszkody.Remove(p);
                    i--;
                }else if ((x-1) == p.getPozycja().X && y == p.getPozycja().Y)
                {
                    przeszkody.Remove(p);
                    i--;
                }else if(x == p.getPozycja().X && (y+1) == p.getPozycja().Y)
                {
                    przeszkody.Remove(p);
                }else if(x == p.getPozycja().X && (y-1) == p.getPozycja().Y)
                {
                    przeszkody.Remove(p);
                    i--;
                }
            }
        }

        public void killThemAll(int x, int y)
        {
            if(x == bomberman.getPosition().X && y == bomberman.getPosition().Y)
            {
                bomberman.killBomberman();
            }else if((x+1) == bomberman.getPosition().X && y == bomberman.getPosition().Y)
            {
                bomberman.killBomberman();
            }else if((x - 1) == bomberman.getPosition().X && y == bomberman.getPosition().Y)
            {
                bomberman.killBomberman();
            }else if(x == bomberman.getPosition().X && (y+1) == bomberman.getPosition().Y)
            {
                bomberman.killBomberman();
            }else if(x == bomberman.getPosition().X && (y - 1) == bomberman.getPosition().Y)
            {
                bomberman.killBomberman();
            }
        }
        
        public void setPrzeszkody(List<Przeszkoda> przeszkody)
        {
            this.przeszkody = przeszkody;
        }

        public void setBomby(List<Bomba> bomby)
        {
            this.bomby = bomby;
        }

        public void setBomberman(Bomberman bomberman)
        {
            this.bomberman = bomberman;
        }

    }
}
