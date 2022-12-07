namespace AdventOfCode.Code1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = FileReader.ReadLines("input.txt");

            var elves = new List<Elf>();
            var currentElf = new Elf();

            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    currentElf.Foods.Add(Convert.ToInt32(line));
                }
                else
                {
                    elves.Add(currentElf);
                    currentElf = new Elf();
                }
            }

            Console.WriteLine($"Elf with most calories: {elves.Max(x => x.Calories)}");

            var topThreeElvesCalories = elves.OrderByDescending(x => x.Calories).Take(3).Sum(x => x.Calories);
            Console.WriteLine($"Top 3 elves with most calories: {topThreeElvesCalories}");
        }
    }

    internal class Elf
    {
        public List<int> Foods { get; }

        public int Calories => Foods.Sum();

        public Elf()
        {
            Foods = new List<int>();
        }
    }
}