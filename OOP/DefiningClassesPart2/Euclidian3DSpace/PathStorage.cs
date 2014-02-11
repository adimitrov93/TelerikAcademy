namespace Euclidian3DSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        public static void Save(List<Point3D> data, string filepath)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filepath);
                StringBuilder output = new StringBuilder();

                foreach (var point in data)
                {
                    output.AppendFormat("({0},{1},{2})", point.X, point.Y, point.Z);
                }

                using (writer)
                {
                    writer.WriteLine(output);
                }

                Console.WriteLine("Save finished.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path cannot be empty.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Invalid path.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred while performing the requested operation.");
            }
        }

        public static List<Point3D> Load(string filepath)
        {
            List<Point3D> result = new List<Point3D>();

            try
            {
                StreamReader reader = new StreamReader(filepath);
                string[] input;

                using (reader)
                {
                    string inputString = reader.ReadLine();
                    input = inputString.Split(new char[] { ',', '(', ')', ' '}, StringSplitOptions.RemoveEmptyEntries);
                }

                for (int i = 0; i < input.Length; i += 3)
                {
                    int x = int.Parse(input[i]);
                    int y = int.Parse(input[i + 1]);
                    int z = int.Parse(input[i + 2]);
                    Point3D newPoint = new Point3D(x, y, z);

                    result.Add(newPoint);
                }

                Console.WriteLine("Load finished.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path cannot be empty.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Invalid path.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred while performing the requested operation.");
            }
            
            return result;
        }
    }
}
