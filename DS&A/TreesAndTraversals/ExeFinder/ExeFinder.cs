// 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.


namespace ExeFinder
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ExeFinder
    {
        public static void Main()
        {
            string directoryToTraverse = "C:\\WINDOWS";

            var exes = new List<string>();

            Traverse(directoryToTraverse, exes);

            foreach (var exe in exes)
            {
                Console.WriteLine(exe);
            }
        }

        static void Traverse(string directoryToTraverse, List<string> result)
        {
            IEnumerable<string> directories = null;
            IEnumerable<string> exes = null;

            try
            {
                exes = Directory.EnumerateFiles(directoryToTraverse, "*.exe");

                result.AddRange(exes);
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                directories = Directory.EnumerateDirectories(directoryToTraverse);

                foreach (var directory in directories)
                {
                    Traverse(directory, result);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
