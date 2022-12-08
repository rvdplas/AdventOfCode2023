namespace AdventOfCode.Code8;

internal class Tree
{
    public int Height { get; set; }
    public bool IsSeen { get; set; }

    public int ScenicScore => ScenicScoreCard.TotalScore();

    public ScenicScoreCard ScenicScoreCard { get; }

    public Tree()
    {
        ScenicScoreCard = new ScenicScoreCard();
    }


    public override string ToString()
    {
        return Height.ToString();
    }
}