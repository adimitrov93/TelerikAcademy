//* Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
//A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash. Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, -
//distributed with appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150). Implement collision detection and scoring system.

using System;
using System.Threading;
using System.Collections.Generic;

struct Dwarf
{
    public int x;
    public int y;
    public string str;
    public ConsoleColor color;
}

struct Rock
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}

class FallingRocks
{
    //Used to print the dwarf and the info text on the right
    static void PrintDwarfOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    //Used to print the rocks
    static void PrintRockOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    //Used to print the side rocks
    static void PrintSideRocks()
    {
        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("/");
            Console.SetCursorPosition(Console.WindowWidth - 21, i);
            Console.Write("\\");

            i++;

            Console.SetCursorPosition(0, i);
            Console.Write("\\");
            Console.SetCursorPosition(Console.WindowWidth - 21, i);
            Console.Write("/");
        }
    }

    //Choose random color for rocks
    static ConsoleColor RandomColor(int color)
    {
        if (color == 0)
        {
            return ConsoleColor.Blue;
        }
        else if (color == 1)
        {
            return ConsoleColor.Cyan;
        }
        else if (color == 2)
        {
            return ConsoleColor.Green;
        }
        else if (color == 3)
        {
            return ConsoleColor.Magenta;
        }
        else if (color == 4)
        {
            return ConsoleColor.Red;
        }
        else
        {
            return ConsoleColor.Yellow;
        }
    }

    //Choose random character for rocks
    static char RandomChar(int ch)
    {
        if (ch == 0)
        {
            return '^';
        }
        else if (ch == 1)
        {
            return '@';
        }
        else if (ch == 2)
        {
            return '*';
        }
        else if (ch == 3)
        {
            return '&';
        }
        else if (ch == 4)
        {
            return '+';
        }
        else if (ch == 5)
        {
            return '%';
        }
        else if (ch == 6)
        {
            return '$';
        }
        else if (ch == 7)
        {
            return '#';
        }
        else if (ch == 8)
        {
            return '!';
        }
        else if (ch == 9)
        {
            return '.';
        }
        else if (ch == 10)
        {
            return ';';
        }
        else
        {
            return '-';
        }
    }

    static void Main()
    {
        //Adjust the console
        Console.WindowHeight = 20;
        Console.WindowWidth = 61;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        //Spawn the dwarf in the middle of the playfield
        Dwarf dwarf = new Dwarf();
        dwarf.x = (Console.WindowWidth - 21) / 2 - 1;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.str = "(0)";
        dwarf.color = ConsoleColor.White;

        Random randomGenerator = new Random();
        List<Rock> rocks = new List<Rock>();
        int lives = 3;
        int health = 100;
        bool hitted = false;

        while (true)
        {
            Console.Clear();

            PrintSideRocks();

            PrintDwarfOnPosition(dwarf.x, dwarf.y, dwarf.str, dwarf.color);

            int length = randomGenerator.Next(1, 4);                            //Random size of the rocks (1, 2 or 3 symbols)
            int xPosition = randomGenerator.Next(1, Console.WindowWidth - 22);  //Random position of the rocks
            int color = randomGenerator.Next(0, 6);                             //Random int for chosing the random color
            int ch = randomGenerator.Next(0, 12);                               //Random int for chosing the random charcter

            for (int i = 0; i < length; i++)
            {
                if (xPosition + i > Console.WindowWidth - 22)                   //If the rock is bigger than the space -> don't print it
                {                                                               //E.g. 3 symbol rock -> xPosition = 58 ->
                    break;                                                      //-> this for will print only 2 symbol rock
                }

                Rock newRock = new Rock();
                newRock.x = xPosition + i;
                newRock.y = 0;
                newRock.c = RandomChar(ch);
                newRock.color = RandomColor(color);
                rocks.Add(newRock);
            }

            foreach (var rock in rocks)                                         //Print the rocks
            {
                PrintRockOnPosition(rock.x, rock.y, rock.c, rock.color);
            }
            
            //Print info
            PrintDwarfOnPosition(Console.WindowWidth - 14, 4, "Health: " + health + "%", ConsoleColor.Green);
            PrintDwarfOnPosition(Console.WindowWidth - 14, 5, "Lives: " + lives, ConsoleColor.Green);
            
            //Moving the dwarf
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x - 1 >= 1)
                    {
                        dwarf.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x + 1 <= Console.WindowWidth - 24)
                    {
                        dwarf.x++;
                    }
                }
            }

            List<Rock> newRocks = new List<Rock>();

            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRock = new Rock();

                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;

                //Check for hit
                if ((newRock.x == dwarf.x || newRock.x == dwarf.x + 1 || newRock.x == dwarf.x + 2) && newRock.y == dwarf.y)
                {
                    health -= 10;
                    PrintDwarfOnPosition(dwarf.x, dwarf.y, dwarf.str, ConsoleColor.Red);
                    hitted = true;

                    if (health <= 0)
                    {
                        lives--;
                        PrintDwarfOnPosition(dwarf.x, dwarf.y, dwarf.str, ConsoleColor.Red);
                        Thread.Sleep(150);
                        health = 100;
                        Console.Clear();
                        rocks.Clear();
                    }

                    if (lives <= 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine("Game Over!!!");
                        Console.SetCursorPosition(5, 7);
                        //Console.Write("Press any key to continue...");            //This 2 lines are used if the program is compiled
                        //Console.ReadKey(true);                                    //and used without Visual Studio
                        return;
                    }
                }

                if (newRock.y < Console.WindowHeight && !(hitted))
                {
                    newRocks.Add(newRock);
                }

                hitted = false;
            }

            rocks = newRocks;

            //Slowing down the game
            Thread.Sleep(150);
        }
    }
}