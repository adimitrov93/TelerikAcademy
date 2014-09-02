using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketQueue
{
    static class Program
    {
        static LinkedList<string> queue = new LinkedList<string>();
        static Dictionary<string, int> namesCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string currentCommand = Console.ReadLine();

            while (currentCommand != "End")
            {
                if (currentCommand.StartsWith("Append"))
                {
                    var name = currentCommand.Split(' ')[1];
                    queue.AddLast(name);

                    if (namesCount.ContainsKey(name))
                    {
                        namesCount[name]++;
                    }
                    else
                    {
                        namesCount[name] = 1;
                    }

                    Console.WriteLine("OK");
                }
                else if (currentCommand.StartsWith("Insert"))
                {
                    var indexAsString = currentCommand.Split(' ')[1];
                    var name = currentCommand.Split(' ')[2];
                    queue.InsertAt(int.Parse(indexAsString), name);
                }
                else if (currentCommand.StartsWith("Find"))
                {
                    var name = currentCommand.Split(' ')[1];
                    if (namesCount.ContainsKey(name))
                    {
                        Console.WriteLine(namesCount[name]);                        
                    }
                    else
                    {
                        Console.WriteLine(0);
                    }
                }
                else if (currentCommand.StartsWith("Serve"))
                {
                    int count = int.Parse(currentCommand.Split(' ')[1]);

                    if (count <= queue.Count)
                    {
                        List<string> result = new List<string>();

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(queue.First.Value);
                            namesCount[queue.First.Value]--;
                            queue.RemoveFirst();
                        }

                        Console.WriteLine(string.Join(" ", result));
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }

                currentCommand = Console.ReadLine();
            }
        }

        static void InsertAt(this LinkedList<string> queue, int index, string value)
        {
            if (index >= 0 && index <= queue.Count)
            {
                if (index == 0)
                {
                    queue.AddFirst(value);
                }
                else if (index == queue.Count)
                {
                    queue.AddLast(value);
                }
                else
                {
                    var current = queue.First;

                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }

                    queue.AddBefore(current, value);
                }

                if (namesCount.ContainsKey(value))
                {
                    namesCount[value]++;
                }
                else
                {
                    namesCount[value] = 1;
                }

                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
