namespace AdventOfCode.Code2;

public static class HandConverter
{
    public static Hand Create(string handInput)
    {
        if (IsRock(handInput))
        {
            return new Rock();
        }

        if (IsPaper(handInput))
        {
            return new Paper();
        }

        if (IsScissors(handInput))
        {
            return new Scissors();
        }

        throw new InvalidOperationException("Invalid hand input.");
    }

    internal static bool IsRock(string input)
    {
        return input.Equals("A") || input.Equals("X");
    }

    internal static bool IsPaper(string input)
    {
        return input.Equals("B") || input.Equals("Y");
    }

    internal static bool IsScissors(string input)
    {
        return input.Equals("C") || input.Equals("Z");
    }
}