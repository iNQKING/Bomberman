using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Program
    {
        static void Main(string[] args)
        {
            Plansza plansza1 = new Plansza(20, 20);
            plansza1.addSpawnPoint(10, 6);
            ;
        }

        enum TypObiektu
        {
            SpawnPoint = 2
        }

        class Plansza
        {
            private TypObiektu[,] rozmiarPlanszy;

            public Plansza(int x, int y)
            {

                rozmiarPlanszy = new TypObiektu[x, y];
            }

            public void addSpawnPoint(int x, int y)
            {
                rozmiarPlanszy[x, y] = TypObiektu.SpawnPoint;
            }
            public void addObstacle(List<Point> obstacle)
            {
                List<int> list = new List<int>();
                list.Add(2);
                list.Add(3);
                list.Add(5);
                list.Add(7);
            }
        }
    }
}