namespace AdventOfCode.Code4;

internal class SectionPair
{
    public Section A { get; set; }

    public Section B { get; set; }

    public SectionPair(string input)
    {
        var split = input.Split(",");
        A = new Section(split[0]);
        B = new Section(split[1]);
    }

    public bool HasFullSectionOverlap()
    {
        return A.Start <= B.Start && A.End >= B.End 
               || B.Start <= A.Start && B.End >= A.End;
    }

    public bool HasSectionOverlap()
    {
        for (int i = A.Start; i <= A.End; i++)
        {
            for (int x = B.Start; x <= B.End; x++)
            {
                if (i == x)
                {
                    return true;
                }
            }
        }

        return false;
    }
}