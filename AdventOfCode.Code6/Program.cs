using System.Runtime.InteropServices;
using AdventOfCode.Code1;

namespace AdventOfCode.Code6
{
    internal class Program
    {
        private static void Main()
        {
            // var lines = FileReader.ReadLines("input_test.txt").ToList();
            var lines = FileReader.ReadLines("input.txt").ToList();

            const int lengthOfMarker = 4;

            var markerPosition = CalculateMarkerPosition(lines.Single(), lengthOfMarker);
            Console.WriteLine($"Marker: {markerPosition}");

            const int lengthMessage = 14;

            var messagePosition = CalculateMarkerPosition(lines.Single(), lengthMessage);
            Console.WriteLine($"Marker: {messagePosition}");
        }

        private static int CalculateMarkerPosition(string buffer, int lengthOfMarker)
        {
            for (int i = 0; i < buffer.Length - lengthOfMarker; i++)
            {
                if (IsMarker(buffer, i, lengthOfMarker))
                {
                    return i + lengthOfMarker;
                }
            }

            throw new InvalidComObjectException("Could not locate marker");
        }

        private static bool IsMarker(string buffer, int currentIndex, int lengthOfMarker)
        {
            var possibleMarker = buffer.Substring(currentIndex, lengthOfMarker);
            return UniqueCharacters(possibleMarker);
        }

        private static bool UniqueCharacters(String str)
        {

            // If at any time we encounter 2
            // same characters, return false
            for (int i = 0; i < str.Length; i++)
            for (int j = i + 1; j < str.Length; j++)
                if (str[i] == str[j])
                    return false;

            // If no duplicate characters
            // encountered, return true
            return true;
        }
    }
}