using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomNumber = random.Next(0, 5);

            if (randomNumber == 0)
            {
                Console.WriteLine("sasho");
            }
            else if (randomNumber == 1)
            {
                Console.WriteLine("daniel");
            }
            else if (randomNumber == 2)
            {
                Console.WriteLine("konstantin");
            }
            else if (randomNumber == 3)
            {
                Console.WriteLine("vesko");
            }
            else
            {
                Console.WriteLine("todor");
            }
        }
    }
}
