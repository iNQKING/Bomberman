using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class ConsoleApplication
    {
        ConsoleOperation console = new ConsoleOperation();
        Map map = new Map();
        Bomberman bomberman = new Bomberman();
        InteractionUser interaction = new InteractionUser();
        CheckGame check = new CheckGame();
        Przeszkody przeszkody = new Przeszkody();

        public void Run()
        {
            int choice;
            String choiceString;

            try
            {
                do
                {
                    Console.Write("\n\n\t\tWITAJ W GRZE BOMBERMAN! \n\n");
                    Console.Write("\t\t1. Graj\n");
                    Console.Write("\t\t0. Wyjście z programu\n");
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
                            console.Przeszkody(przeszkody, map);
                            console.DrawBomberman(bomberman, map);
                            while (true)
                            {

                             point = interaction.Move(bomberman);
                             console.DrawBomberman(bomberman, map);
                             console.clearPoint(point);
                                //System.Threading.Thread.Sleep(120000);
                                if (check.CrashWall(bomberman) || check.CrashBody(bomberman, map))
                                {
                                    Console.Clear();
                                    Console.Write("KONIEC Gry!");
                                    //Console.Beep(1000, 1000);
                                    break;
                                }
                            }
                            break;

                        case 0:
                            Console.Write("\n\n\n\n\t\tŻYCZĘ MIŁEGO DNIA :)");
                            break;
                        default:
                            break;
                    }
                } while (choice == 1 || choice == 2 || choice == 3);

            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("\nWystąpił błąd w programie: {0}", e.Message));
            }
        }
    }
}
