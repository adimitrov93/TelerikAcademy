namespace TreeFromFilesAndFolders
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        private IList<File> files;
        private IList<Folder> folders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.folders = new List<Folder>();
        }

        public string Name { get; private set; }

        public IList<File> Files
        {
            get
            {
                return new List<File>(this.files);
            }

            private set
            {
                this.files = value;
            }
        }

        public IList<Folder> Folders
        {
            get
            {
                return new List<Folder>(this.folders);
            }

            private set
            {
                this.folders = value;
            }
        }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.folders.Add(folder);
        }
    }
}
