namespace TreeFromFilesAndFolders
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class EntryPoint
    {
        public static void Main()
        {
            var info = new DirectoryInfo("C:\\WINDOWS");
            var root = new Folder(info.Name);

            Traverse(root, info.FullName);
            Print(root, 0);
        }

        private static void Print(Folder root, int indent)
        {
            Console.WriteLine(new string(' ', indent) + root.Name);

            foreach (var file in root.Files)
            {
                Console.WriteLine(new string(' ', indent + 4) + file.Name);
            }

            foreach (var folder in root.Folders)
            {
                Print(folder, indent + 4);
            }
        }

        static void Traverse(Folder root, string directoryToTraverse)
        {
            try
            {
                var files = Directory.EnumerateFiles(directoryToTraverse);

                foreach (var file in files)
                {
                    var info = new FileInfo(file);
                    root.AddFile(new File(info.Name, info.Length));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                var directories = Directory.EnumerateDirectories(directoryToTraverse);

                foreach (var directory in directories)
                {
                    var info = new DirectoryInfo(directory);
                    var folder = new Folder(info.Name);
                    root.AddFolder(folder);
                    Traverse(folder, info.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
