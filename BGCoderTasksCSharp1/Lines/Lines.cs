using System;

class Lines
{
    static void Main()
    {
        byte[] array = new byte[8];

        for (int i = 0; i < 8; i++)
        {
            array[i] = byte.Parse(Console.ReadLine());
        }

        int longestLine = 0;
        int currentLine = 0;
        int linesCount = 0;
        byte mask = 1;

        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                if ((array[i] & (mask << j)) != 0)
                {
                    currentLine = 1;

                    for (byte k = 1; k < 8 - i; k++)
                    {
                        if ((array[i + k] & (mask << j)) != 0)
                        {
                            currentLine++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentLine > longestLine)
                    {
                        longestLine = currentLine;
                        linesCount = 1;
                    }
                    else if (currentLine == longestLine)
                    {
                        linesCount++;
                    }

                    currentLine = 1;

                    for (byte k = 1; k < 8 - j; k++)
                    {
                        if ((array[i] & (mask << j + k)) != 0)
                        {
                            currentLine++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentLine > longestLine)
                    {
                        longestLine = currentLine;
                        linesCount = 1;
                    }
                    else if (currentLine == longestLine)
                    {
                        linesCount++;
                    }
                }
            }
        }

        Console.WriteLine(longestLine);

        if (longestLine == 1)
        {
            Console.WriteLine(linesCount / 2);
        }
        else
        {
            Console.WriteLine(linesCount);
        }
    }
}