using System.Text;
using AdventOfCode.Code1;
using System.Xml.Linq;

namespace AdventOfCode.Code5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var lines = FileReader.ReadLines("input_test.txt").ToList();
            var lines = FileReader.ReadLines("input.txt").ToList();

            var crane9000 = new Crane(lines);
            ExecuteOperationsStep1(crane9000);
            OuputResult(crane9000);

            var crane9001 = new Crane(lines);
            ExecuteOperationsStep2(crane9001);
            OuputResult(crane9001);
        }

        private static void ExecuteOperationsStep1(Crane crane)
        {
            foreach (var op in crane.Operations)
            {
                for (int i = 0; i < op.CratesToMove; i++)
                {
                    // Pickup crate
                    var crateToMove = crane.Stack[op.From].Last();

                    // Remove crate from current location
                    crane.Stack[op.From].Remove(crateToMove);

                    // Add crate on top of new location
                    crane.Stack[op.To].Add(crateToMove);
                }
            }
        }

        private static void ExecuteOperationsStep2(Crane crane)
        {
            foreach (var op in crane.Operations)
            {
                // Pickup crate
                int cratesToSkip = crane.Stack[op.From].Count - op.CratesToMove;

                var cratesToMove = crane.Stack[op.From]
                    .Skip(cratesToSkip)
                    .Take(op.CratesToMove)
                    .ToList();

                // Remove crate from current location
                foreach (var crate in cratesToMove)
                {
                    crane.Stack[op.From].Remove(crate);
                }

                // Add crate on top of new location
                crane.Stack[op.To].AddRange(cratesToMove);
            }
        }

        private static void OuputResult(Crane crane)
        {
            var textBuilder = new StringBuilder();

            foreach (var key in crane.Stack.Keys)
            {
                Console.WriteLine($"{key} - {crane.Stack[key].LastOrDefault()?.Name} ");
                textBuilder.Append(crane.Stack[key].LastOrDefault()?.Name);
            }

            Console.WriteLine($"Result: {textBuilder}");
        }
    }
}