using System;
using System.Collections.Generic;
using System.Threading;

namespace Bomberman
{
    class ConsoleApplication
    {
        ConsoleOperation console = new ConsoleOperation();
        Map map = new Map();
        

        InteractionUser interaction = new InteractionUser();
        Detonator detonator = new Detonator();

        Bomberman bomberman;
        List<Przeszkoda> przeszkody = new List<Przeszkoda>();
        List<Bomba> bomby = new List<Bomba>();

        Thread oThread;
            

        public ConsoleApplication()
        {
            bomberman = new Bomberman(10, 10);

            przeszkody.Add(new Przeszkoda(5, 5));
            przeszkody.Add(new Przeszkoda(4, 4));
            przeszkody.Add(new Przeszkoda(9, 9));
            przeszkody.Add(new Przeszkoda(12, 12));
            przeszkody.Add(new Przeszkoda(15, 15));

            console.setPrzeszkody(przeszkody);
            console.setBomberman(bomberman);
            console.setBomby(bomby);

            interaction.setPrzeszkody(przeszkody);
            interaction.setBomberman(bomberman);
            interaction.setBomby(bomby);

            detonator.setBomby(bomby);
            detonator.setConsoleOperation(console);

            oThread = new Thread(new ThreadStart(detonator.timeTick));
        }

        public void Run()
        {
            int choice;
            String choiceString;

            try
            {
                //do
                //{
                    Console.Clear();
                    Console.Write("\n\n\t\tWITAJ W GRZE BOMBERMAN! \n\n");
                    Console.Write("\t\t1. Graj\n");
                    Console.Write("\t\t0. Wyjście z programu\n");
                    Console.Write("\t\tWSAD - Poruszanie\n");
                    Console.Write("\t\tX - bomba 3s\n");
                    Console.Write("\t\tZ - bomba 5s\n");
                    Console.Write("\n\n\t\tTwój wybór: ");

                    choiceString = Console.ReadLine();
                    choice = int.Parse(choiceString);
                    Point point;

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            console.ClearMap(map);
                            console.DrawMap(map);
                            console.drawPrzeszkody();
                            console.drawBomberman();
                            
                            oThread.Start();
                            while (przeszkody.Count >= 1 && bomberman.isAlive())
                            {
                                point = interaction.Move();
                                console.drawPrzeszkody();
                                console.drawBomby();
                                if (point != null)
                                    console.clearPoint(point);
                                console.drawBomberman();
                            }


                            Console.Clear();
                            console.ClearMap(map);  
                            Console.Write("\n\n\t\tKONIEC BOMBERMANA! \n\n");
                            Thread.Sleep(1000);

                            break;

                        case 0:
                            Console.Write("\n\n\n\n\t\tŻYCZĘ MIŁEGO DNIA :)");
                            break;
                        default:
                            break;
                    }
                //} while (choice == 1);

            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("\nWystąpił błąd w programie: {0}", e.Message));
            }
        }
    }
}
