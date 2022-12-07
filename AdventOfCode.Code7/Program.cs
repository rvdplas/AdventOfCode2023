using AdventOfCode.Code1;

namespace AdventOfCode.Code7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var lines = FileReader.ReadLines("input_test.txt").ToList();
            var lines = FileReader.ReadLines("input.txt").ToList();

            var disk = ProcessInfo(lines);
            PrintOutput(disk, 0);

            CalculateTotalSize(100000, disk);
            Console.WriteLine($"Total size: {TotalSize}");

            FindDirectoryToDelete(disk);
            Console.WriteLine($"Smallest directory Size: {SmallDirectory.Size}");
        }

        private static void FindDirectoryToDelete(Directory disk)
        {
            long totalSpace = 70000000;
            long neededSpace = 30000000;
            long freeSpace = totalSpace - disk.Size;

            FindSmallestDirectoryToDelete(disk, neededSpace - freeSpace);
        }

        private static Directory SmallDirectory = null;

        private static void FindSmallestDirectoryToDelete(Directory current, long spaceToFind)
        {
            if (current.Size > spaceToFind)
            {
                if (SmallDirectory == null)
                {
                    SmallDirectory = current;
                }
                else
                {
                    if (SmallDirectory.Size > current.Size)
                    {
                        SmallDirectory = current;
                    }
                }

                foreach (var subDir in current.SubDirectories)
                {
                    FindSmallestDirectoryToDelete(subDir, spaceToFind);
                }
            }
            else
            {
                // don't bother with subdirectories if the parent directory doesn't have enough size...
            }
        }

        public static long TotalSize = 0;

        private static void CalculateTotalSize(int sizeToFind, Directory directory)
        {
            if (directory.Name != "/")
            {
                if (directory.Size <= sizeToFind)
                {
                    TotalSize += directory.Size;
                }
            }

            foreach (var subDir in directory.SubDirectories)
            {
                CalculateTotalSize(sizeToFind, subDir);
            }
        }

        private static void PrintOutput(Directory currentDirectory, int index)
        {
            Console.WriteLine($"{CalculateSpace(index)}- {currentDirectory.Name} (dir, size={currentDirectory.Size})");
            foreach (var subDir in currentDirectory.SubDirectories)
            {
                PrintOutput(subDir, index + 2);
            }

            foreach (var file in currentDirectory.Files)
            {
                var spaces = CalculateSpace(index + 2);
                Console.WriteLine($"{spaces}-{file.Name} (file, size={file.Size})");
            }
        }

        private static string CalculateSpace(int index)
        {
            var spaces = "";
            for (var i = 0; i < index; i++)
            {
                spaces += " ";
            }

            return spaces;
        }
        
        private static Directory ProcessInfo(List<string> commands)
        {
            Directory rootDirectory = null;
            Directory current = null;

            for (int i = 0; i < commands.Count; i++)
            {
                // list directory
                if (commands[i].StartsWith("$ ls"))
                {
                    continue;
                }

                // process root
                if (commands[i].StartsWith("$ cd /"))
                {
                    rootDirectory = new Directory("/");
                    current = rootDirectory;
                    continue;
                }

                if (commands[i].StartsWith("$ cd .."))
                {
                    current = current.ParentDirectory;
                    continue;
                }

                // process moving into subdir
                if (commands[i].StartsWith("$ cd"))
                {
                    // switch to subdirectory
                    var spliDit = commands[i].Split(" ");
                    var directoryNameToFind = spliDit[2];

                    current = current.SubDirectories.Single(x => x.Name.Equals(directoryNameToFind));
                    continue;
                }

                // Process dir
                if (commands[i].StartsWith("dir"))
                {
                    var directoryName = commands[i].Split(" ")[1];

                    var subDirectory = new Directory(directoryName);
                    subDirectory.ParentDirectory = current;
                    current.SubDirectories.Add(subDirectory);
                    continue;
                }

                // Process file
                var splitFile = commands[i].Split(" ");
                var file = new File(splitFile[1], Convert.ToInt32(splitFile[0]));
                current.Files.Add(file);
            }

            return rootDirectory;
        }
    }
}