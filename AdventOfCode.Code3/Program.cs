using System.Reflection.Metadata.Ecma335;
using AdventOfCode.Code1;

namespace AdventOfCode.Code3
{
    internal class Program
    {
        private static void Main()
        {
            var priorityIndex = CreatePriorityIndex();
            // var lines = FileReader.ReadLines("input_test.txt");
            var lines = FileReader.ReadLines("input.txt");

            var rucksacks = lines.Select(line => new Rucksack(line)).ToList();
            Console.WriteLine($"Sum of priorities {rucksacks.Sum(x => x.GetPriority(priorityIndex))}");

            var count = 0;

            for (int i = 0; i < rucksacks.Count / 3; i++)
            {
                var batch = rucksacks.Skip(i*3).Take(3);

                var batchCharacter = batch.ElementAt(0).FindBadge(batch.ElementAt(1), batch.ElementAt(2));
                count += priorityIndex[batchCharacter];
            }

            Console.WriteLine($"Sum of badges: {count}");
        }

        private static Dictionary<char, int> CreatePriorityIndex()
        {
            var priorityIndex = new Dictionary<char, int>();
            var value = 1;

            for (char c = 'a'; c <= 'z'; c++)
            {
                priorityIndex.Add(c, value);
                value++;
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                priorityIndex.Add(c, value);
                value++;
            }

            return priorityIndex;
        }
    }

    internal class Rucksack
    {
        private readonly List<char> _firstCompartmentChars = new();
        private readonly List<char> _secondCompartmentChars = new();
        private char _errorChar;

        public Rucksack(string input)
        {
            ParseInput(input);
            FindErrorInCompartment();
        }

        public int GetPriority(Dictionary<char, int> priorityIndex)
        {
            return priorityIndex.ContainsKey(_errorChar) ? priorityIndex[_errorChar] : 0;
        }

        public bool ExistsInCompartment(char character)
        {
            return _firstCompartmentChars.Contains(character)
                   || _secondCompartmentChars.Contains(character);
        }

        public IReadOnlyList<char> GetItems()
        {
            var x = new List<char>(_firstCompartmentChars);
            x.AddRange(_secondCompartmentChars);

            return x;
        }

        private void FindErrorInCompartment()
        {
            foreach (var character in _firstCompartmentChars.Where(character => _secondCompartmentChars.Contains(character)))
            {
                _errorChar = character;
                break;
            }
        }

        private void ParseInput(string input)
        {
            var half = input.Length / 2;
            var firstCompartmentText = input[..(half)];
            var secondCompartmentText = input[(half)..];

            foreach (var character in firstCompartmentText)
            {
                _firstCompartmentChars.Add(character);
            }

            foreach (var character in secondCompartmentText)
            {
                _secondCompartmentChars.Add(character);
            }
        }
    }

    internal static class RucksackExtension
    {
        internal static char FindBadge(this Rucksack a, Rucksack b, Rucksack c)
        {
            foreach (var item in a.GetItems())
            {
                if (b.ExistsInCompartment(item) && c.ExistsInCompartment(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("Could not find badge!");
        }
    }
}