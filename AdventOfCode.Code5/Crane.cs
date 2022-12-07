namespace AdventOfCode.Code5;

internal class Crane
{
    public List<CraneOperations> Operations { get; }
    public Dictionary<int, List<Crate>> Stack { get; }

    public Crane(List<string> lines)
    {
        var indexOfCraneOperations = FindIndexOfCraneOperations(lines);

        Stack = ParseCrates(lines.Take(indexOfCraneOperations));
        Operations = ParseOperations(lines.Skip(indexOfCraneOperations + 1));
    }

    private static Dictionary<int, List<Crate>> ParseCrates(IEnumerable<string> input)
    {
        var crateStack = new Dictionary<int, List<Crate>>();

        // get last line first
        foreach (var s in input.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            crateStack.Add(Convert.ToInt32(s), new List<Crate>());
        }

        //     [D]   
        // [N] [C]   
        // [Z] [M] [P]

        // parse previous lines
        foreach (var line in input.Take(input.Count() - 1))
        {
            // ...#[D]#...
            var crateIndex = 1;

            int numberOfChars = 4;
            int numberOfCrates = Convert.ToInt32(Math.Ceiling(line.Length / 4.0));

            for (int i = 0; i < numberOfCrates;)
            {
                var crateText = line.Substring(i * numberOfChars, 3);

                var crate = CrateFactory.Create(crateText);
                if (crate != null)
                {
                    crateStack[crateIndex].Add(crate);
                }

                crateIndex++;
                i++;
            }
        }

        // Reverse order of crates as we move from top crate to lower...
        foreach (var key in crateStack.Keys)
        {
            crateStack[key].Reverse();
        }

        return crateStack;
    }

    private static List<CraneOperations> ParseOperations(IEnumerable<string> input)
    {
        return input.Select(line => new CraneOperations(line)).ToList();
    }

    private static int FindIndexOfCraneOperations(List<string> lines)
    {
        return lines.FindIndex(string.IsNullOrEmpty);
    }
}