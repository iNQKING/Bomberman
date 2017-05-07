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
                    Console.Write("\t\t2. Jak grać?\n");
                    Console.Write("\t\t3. O grze\n");
                    Console.Write("\t\t0. Wyjście z programu\n");
                    Console.Write("\n\n\t\tTwój wybór: ");

                    choiceString = Console.ReadLine();
                    choice = int.Parse(choiceString);

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            while (true)
                            {
                                console.ClearMap(map);
                                console.DrawMap(map);
                                console.DrawBomberman(bomberman, map);
                                interaction.Move(bomberman);
                                if (check.CrashWall(bomberman) || check.CrashBody(bomberman, map))
                                {
                                    Console.WriteLine("\n\nKONIEC!   LICZBA ZDOBYTYCH PUNKTÓW: {0}", console.Score);
                                    Console.Beep(1000, 1000);
                                    break;
                                }
                            }
                            break;

                        case 0:
                            Console.Write("\n\n\n\n\t\tŻYCZĘ MIŁEGO DNIA :)");
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
