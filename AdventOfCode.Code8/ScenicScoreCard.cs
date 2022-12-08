namespace AdventOfCode.Code8;

internal class ScenicScoreCard
{
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public int TotalScore()
    {
        return Left * Bottom * Right * Top;
    }
}