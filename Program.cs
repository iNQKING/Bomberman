using System;
using System.Collections.Generic;
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
        class Plansza
        {
            private int[,] rozmiarPlanszy;

            public Plansza(int x, int y)
            {

                rozmiarPlanszy = new int[x, y];
            }

            public void addSpawnPoint(int x, int y)
            {
                rozmiarPlanszy[x, y] = 2;
            }
            public void addObstacle(int x, int y)
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