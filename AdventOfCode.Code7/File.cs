namespace AdventOfCode.Code7;

internal class File
{
    public string Name { get; }
    public long Size { get; }

    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }

    public override string ToString()
    {
        return $"{Name} - {Size}";
    }
}