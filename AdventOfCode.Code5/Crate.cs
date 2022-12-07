namespace AdventOfCode.Code5;

internal class Crate
{
    public string Name { get; }

    internal Crate(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"[{Name}]";
    }
}