using AdventOfCode.Code1;

namespace AdventOfCode.Code4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var lines = FileReader.ReadLines("input_test.txt");
            var lines = FileReader.ReadLines("input.txt");

            var sectionPairs = lines.Select(l => new SectionPair(l))
                .ToList();

            int fullOverlapCounter = sectionPairs.Count(pair => pair.HasFullSectionOverlap());
            Console.WriteLine($"Overlap count: {fullOverlapCounter}");

            int SectionOverlapCounter = sectionPairs.Count(pair => pair.HasSectionOverlap());
            Console.WriteLine($"Overlap count: {SectionOverlapCounter}");

            foreach (var pair in sectionPairs)
            {
                if (pair.HasSectionOverlap() == false)
                {
                    Console.WriteLine($"{pair.A.Start}-{pair.A.End} # {pair.B.Start}-{pair.B.End}");
                }
                
            }
        }
    }
}