namespace AdventOfCode.Code2;

internal class RockPaperScissorUpgrade
{
    public int Score { get; }

    public RockPaperScissorUpgrade(string line)
    {
        var splittedValues = line.Split(" ");

        var opponentHand = splittedValues[0];
        var result = splittedValues[1];

        Score = CalculateScore(HandConverter.Create(opponentHand), ConvertResult(result));
    }

    private static int ConvertResult(string result)
    {
        return result switch
        {
            "X" => -1,
            "Y" => 0,
            "Z" => 1,
            _ => throw new InvalidOperationException("Invalid result input")
        };
    }

    private static int CalculateScore(Hand opponentHand, int result)
    {
        return HandScore(opponentHand, result) + ResultScore(result);
    }

    private static int ResultScore(int result)
    {
        return result switch
        {
            -1 => 0,
            0 => 3,
            1 => 6,
            _ => throw new InvalidOperationException("Invalid result input")
        };
    }

    private static int HandScore(Hand opponentHand, int result)
    {
        switch (result)
        {
            case -1:
                switch (opponentHand)
                {
                    case Rock:
                        return new Scissors().HandScore;
                    case Paper:
                        return new Rock().HandScore;
                    case Scissors:
                        return new Paper().HandScore;
                }
                break;

            case 0:
                return opponentHand.HandScore;

            case 1:
                switch (opponentHand)
                {
                    case Rock:
                        return new Paper().HandScore;
                    case Paper:
                        return new Scissors().HandScore;
                    case Scissors:
                        return new Rock().HandScore;
                }

                break;
        }

        throw new InvalidOperationException("Invalid input for opponentHand and result");
    }
}