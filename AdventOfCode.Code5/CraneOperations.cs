namespace AdventOfCode.Code5;

internal class CraneOperations
{
    public int CratesToMove { get; }
    public int From { get; }
    public int To { get; }

    public CraneOperations(string input)
    {
        var split = input.Split(" ");
        CratesToMove = Convert.ToInt32(split[1]);
        From = Convert.ToInt32(split[3]);
        To = Convert.ToInt32(split[5]);
    }
}