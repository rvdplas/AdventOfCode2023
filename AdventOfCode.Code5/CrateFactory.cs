namespace AdventOfCode.Code5;

internal static class CrateFactory
{
    public static Crate? Create(string input)
    {
        return input.All(x => x.Equals(' ')) ? null : new Crate(input[1].ToString());
    }
}