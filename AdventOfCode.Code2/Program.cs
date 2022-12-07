using AdventOfCode.Code1;

namespace AdventOfCode.Code2
{
    internal class Program
    {
        private static void Main()
        {
            var lines = FileReader.ReadLines("input.txt");

            var outcomes = lines.Select(line => new RockPaperScissor(line)).ToList();
            Console.WriteLine($"Score: {outcomes.Sum(x => x.Score)}");

            var outcomes2 = lines.Select(line => new RockPaperScissorUpgrade(line)).ToList();
            Console.WriteLine($"Score: {outcomes2.Sum(x => x.Score)}");
        }
    }
}