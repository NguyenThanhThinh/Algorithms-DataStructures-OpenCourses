namespace _02.TraverseDirectories
{
    using System;
    using System.IO;
    using System.Linq;

    using File = _02.TraverseDirectories.File;

    public class TraverseDirs
    {
        public static void Main(string[] args)
        {
            const string StartFolderPath = @"D:\Downloads";
            Folder startFolder = new Folder(StartFolderPath);
            BuildTree(startFolder);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Total size: {0}", GetFolderSize(startFolder));
        }

        public static long GetFolderSize(Folder rootFolder)
        {
            if (rootFolder == null)
            {
                return 0;
            }

            long childSum = 0;

            foreach (var folder in rootFolder.Folders)
            {
                childSum += GetFolderSize(folder);
            }

            return childSum + rootFolder.Files.Sum(f => f.Size);
        }

        private static void BuildTree(Folder folder)
        {
            Console.WriteLine(folder.Name);
            FileInfo[] files = { };
            try
            {
                files = new DirectoryInfo(folder.Name).GetFiles();
            }
            catch (UnauthorizedAccessException uae)
            {
            }

            foreach (var childFile in files)
            {
                TraverseDirectories.File file = new TraverseDirectories.File(childFile.FullName, childFile.Length);
                folder.Files.Add(file);
            }

            DirectoryInfo[] folders = { };
            try
            {
                folders = new DirectoryInfo(folder.Name).GetDirectories();
            }
            catch (UnauthorizedAccessException uae)
            {
            }

            foreach (var childFolder in folders)
            {
                Folder customFolder = new Folder(childFolder.FullName);
                folder.Folders.Add(customFolder);
                BuildTree(customFolder);
            }
        }
    }
}
