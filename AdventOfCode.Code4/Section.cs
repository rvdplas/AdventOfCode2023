namespace AdventOfCode.Code4;

internal class Section
{
    public int Start { get;  }
    public int End { get; }

    public Section(string input)
    {
        var split = input.Split('-');
        Start = Convert.ToInt32(split[0]);
        End = Convert.ToInt32(split[1]);
    }
}