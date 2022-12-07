namespace AdventOfCode.Code7;

internal class Directory
{
    public string Name { get; set; }

    public long Size
    {
        get
        {
            return SubDirectories.Sum(x => x.Size) + Files.Sum(x => x.Size);
        }
    }

    public Directory(string name)
    {
        Name = name;
        SubDirectories = new List<Directory>();
        Files = new List<File>();
    }

    public Directory ParentDirectory { get; set; }
    public List<Directory> SubDirectories { get; }
    public List<File> Files { get; }

    public override string ToString()
    {
        return $"{Name} - {Size}";
    }
}