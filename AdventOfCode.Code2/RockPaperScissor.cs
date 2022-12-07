namespace AdventOfCode.Code2;

internal class RockPaperScissor
{
    public int Score { get; }

    public RockPaperScissor(string line)
    {
        var splittedValues = line.Split(" ");

        var opponentHand = splittedValues[0];
        var hand = splittedValues[1];

        Score = CalculateScore(opponentHand, hand);
    }

    private static int CalculateScore(string opponentHand, string hand)
    {
        return HandScore(hand) + ResultScore(opponentHand, hand);
    }

    private static int ResultScore(string opponentHand, string hand)
    {
        if ((IsRock(hand) && IsRock(opponentHand))
            || (IsPaper(hand) && IsPaper(opponentHand))
            || (IsScissors(hand) && IsScissors(opponentHand)))
        {
            return 3;
        }

        if ((IsRock(hand) && IsScissors(opponentHand))
            || (IsPaper(hand) && IsRock(opponentHand))
            || (IsScissors(hand) && IsPaper(opponentHand)))
        {
            return 6;
        }

        return 0;
    }

    private static bool IsRock(string input)
    {
        return input.Equals("A") || input.Equals("X");
    }

    private static bool IsPaper(string input)
    {
        return input.Equals("B") || input.Equals("Y");
    }

    private static bool IsScissors(string input)
    {
        return input.Equals("C") || input.Equals("Z");
    }

    private static int HandScore(string hand)
    {
        return hand switch
        {
            "X" => 1,
            "Y" => 2,
            "Z" => 3,
            _ => throw new InvalidOperationException("Invalid hand!")
        };
    }
}