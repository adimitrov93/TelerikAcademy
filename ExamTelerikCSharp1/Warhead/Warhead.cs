using System;
using System.Collections.Generic;

struct Capacitor
{
    public int i;
    public int j;
}
struct Sistem
{
    public int i;
    public int j;
}

class Warhead
{
    static void Main()
    {
        char[,] board = new char[16, 16];

        char input;

        List<Capacitor> capacitors = new List<Capacitor>();
        List<Sistem> sistems = new List<Sistem>();

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                input = (char)Console.Read();
                if (j < 16)
                {
                    board[i, j] = input;
                }
            }
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (board[i, j] == '1')
                {
                    Capacitor newCapacitor = new Capacitor();
                    newCapacitor.i = i;
                    newCapacitor.j = j;
                    capacitors.Add(newCapacitor);
                }
            }
        }

        bool uslovie;

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (board[i, j] == '0' && ((((i >= 1) && (i <= 6)) || ((i >= 9) && (i <= 14))) && (j >= 1) && (j <= 14)))
                {
                    uslovie = board[i - 1, j - 1] == '1' && board[i - 1, j] == '1' && board[i - 1, j + 1] == '1' && board[i, j - 1] == '1' && board[i, j + 1] == '1' && board[i + 1, j - 1] == '1' && board[i + 1, j] == '1' && board[i + 1, j + 1] == '1';
                    if (uslovie)
                    {
                        Sistem newSistem = new Sistem();
                        newSistem.i = i;
                        newSistem.j = j;
                        sistems.Add(newSistem);
                    }
                }
            }
        }

        int leftSideSistems = 0;
        int rigtSideSistems = 0;

        foreach (var sistem in sistems)
        {
            if (sistem.j <= 6)
            {
                leftSideSistems++;
            }
            else if (sistem.j >= 9)
            {
                rigtSideSistems++;
            }
        }

        string command;
        int commandI;
        int commandJ;
        bool onCapacitor = false;

        while (true)
        {
            command = Console.ReadLine();

            if (command == "cut")
            {
                string secCommand = Console.ReadLine();

                if (secCommand == "red")
                {
                    if (leftSideSistems == 0)
                    {
                        Console.WriteLine(rigtSideSistems);
                        Console.WriteLine("disarmed");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(leftSideSistems);
                        Console.WriteLine("BOOM");
                        return;
                    }
                }
                else
                {
                    if (rigtSideSistems == 0)
                    {
                        Console.WriteLine(leftSideSistems);
                        Console.WriteLine("disarmed");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(rigtSideSistems);
                        Console.WriteLine("BOOM");
                        return;
                    }
                }
            }

            commandI = int.Parse(Console.ReadLine());
            commandJ = int.Parse(Console.ReadLine());

            if (command == "hover")
            {
                onCapacitor = false;

                foreach (var capacitor in capacitors)
                {
                    if (capacitor.i == commandI && capacitor.j == commandJ)
                    {
                        onCapacitor = true;
                        break;
                    }
                }

                if (onCapacitor)
                {
                    Console.WriteLine('*');
                }
                else
                {
                    Console.WriteLine('-');
                }
            }
            else if (command == "operate")
            {
                foreach (var capacitor in capacitors)
                {
                    if (capacitor.i == commandI && capacitor.j == commandJ)
                    {
                        Console.WriteLine("missed");
                        Console.WriteLine(leftSideSistems + rigtSideSistems);
                        Console.WriteLine("BOOM");
                        return;
                    }
                }

                //foreach (var sistem in sistems)
                //{
                //    Console.WriteLine("Sistem at [{0}, {1}]", sistem.i, sistem.j);
                //    Console.WriteLine("left: {0}", leftSideSistems);
                //    Console.WriteLine("right: {0}", rigtSideSistems);
                //}

                List<Sistem> newSistems = new List<Sistem>();

                foreach (var sistem in sistems)
                {
                    if (sistem.i == commandI && sistem.j == commandJ)
                    {
                        if (commandJ <= 6)
                        {
                            leftSideSistems--;
                        }
                        else
                        {
                            rigtSideSistems--;
                        }
                        continue;

                    }
                    newSistems.Add(sistem);
                }

                sistems = newSistems;

                //foreach (var sistem in sistems)
                //{
                //    Console.WriteLine("Sistem at [{0}, {1}]", sistem.i, sistem.j);
                //    Console.WriteLine("left: {0}", leftSideSistems);
                //    Console.WriteLine("right: {0}", rigtSideSistems);
                //}
            }
        }
    }
}