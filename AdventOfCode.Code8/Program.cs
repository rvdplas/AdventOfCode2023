using AdventOfCode.Code1;

namespace AdventOfCode.Code8
{
    internal class Program
    {
        private static void Main()
        {
            // var lines = FileReader.ReadLines("input_test.txt").ToList();
            var lines = FileReader.ReadLines("input.txt").ToList();

            var forest = new Forest(lines);
            // forest.Print();

            var visibleTrees = forest.FindVisibleTrees();
            Console.WriteLine($"visible trees: {visibleTrees}");

            var highestScenicScore = forest.FindHighestScenicScore();
            Console.WriteLine($"High Scenic score: {highestScenicScore}");
        }
    }

    internal class Forest
    {
        private Tree[,] _forest;

        public Forest(List<string> treeLines)
        {
            ConvertTreeLinesIntoForest(treeLines);
        }

        private void ConvertTreeLinesIntoForest(IReadOnlyList<string> treeLines)
        {
            _forest = new Tree[treeLines.Count, treeLines[0].Length];

            for (int x = 0; x < treeLines.Count; x++)
            {
                for (int y = 0; y < treeLines[x].Length; y++)
                {
                    _forest[x, y] = new Tree
                    {
                        Height = Convert.ToInt32(char.GetNumericValue(treeLines[x][y]))
                    };
                }
            }
        }

        internal void Print()
        {
            for (int x = 0; x < _forest.GetLength(0); x += 1)
            {
                for (int y = 0; y < _forest.GetLength(1); y += 1)
                {
                    Console.Write($"{_forest[x, y]} ");
                }
                Console.WriteLine("");
            }
        }

        public int FindVisibleTrees()
        {
            var rows = _forest.GetLength(0);
            var columns = _forest.GetLength(1);

            for (int x = 0; x < rows; x += 1)
            {
                for (int y = 0; y < columns; y += 1)
                {
                    var checkLeft = CheckLeftTree(x, y, _forest);
                    var checkRight = CheckRightTree(x, y, _forest, columns);
                    var checkTop = CheckTopTree(x, y, _forest);
                    var checkBottom = CheckBottomTree(x, y, _forest, rows);

                    if (checkLeft || checkRight || checkTop || checkBottom)
                    {
                        _forest[x, y].IsSeen = true;
                    }
                }
            }

            return CountVisibleTrees();
        }

        private static bool CheckLeftTree(int x, int y, Tree[,] forest)
        {
            var isVisible = true;
            var index = y;
            int visibleTrees = 0;

            while (index > 0 && isVisible)
            {
                if (forest[x, y].Height <= forest[x, index - 1].Height)
                {
                    isVisible = false;

                    if (forest[x, y].Height == forest[x, index - 1].Height)
                    {
                        visibleTrees++;
                    }

                    break;
                }
                index--;
                visibleTrees++;
            }

            forest[x, y].ScenicScoreCard.Left = visibleTrees;

            return isVisible;
        }

        private static bool CheckRightTree(int x, int y, Tree[,] forest, int columns)
        {
            var isVisible = true;
            var index = y;
            int visibleTrees = 0;

            while (index < columns - 1 && isVisible)
            {
                if (forest[x, y].Height <= forest[x, index + 1].Height)
                {
                    isVisible = false;

                    if (forest[x, y].Height == forest[x, index + 1].Height)
                    {
                        visibleTrees++;
                    }

                    break;
                }
                index++;
                visibleTrees++;
            }

            forest[x, y].ScenicScoreCard.Right = visibleTrees;

            return isVisible;
        }

        private static bool CheckTopTree(int x, int y, Tree[,] forest)
        {
            var isVisible = true;
            var index = x;
            int visibleTrees = 0;

            while (index > 0 && isVisible)
            {
                if (forest[x, y].Height <= forest[index - 1, y].Height)
                {
                    isVisible = false;

                    if (forest[x, y].Height == forest[index - 1, y].Height)
                    {
                        visibleTrees++;
                    }

                    break;
                }

                index--;
                visibleTrees++;
            }

            forest[x, y].ScenicScoreCard.Top = visibleTrees;

            return isVisible;
        }

        private static bool CheckBottomTree(int x, int y, Tree[,] forest, int rows)
        {
            var isVisible = true;
            var index = x;
            int visibleTrees = 0;

            while (index < rows - 1 && isVisible)
            {
                if (forest[x, y].Height <= forest[index + 1, y].Height)
                {
                    isVisible = false;

                    if (forest[x, y].Height == forest[index + 1, y].Height)
                    {
                        visibleTrees++;
                    }
                    break;
                }
                index++;
                visibleTrees++;
            }

            forest[x, y].ScenicScoreCard.Bottom = visibleTrees;

            return isVisible;
        }

        private int CountVisibleTrees()
        {
            var rows = _forest.GetLength(0);
            var columns = _forest.GetLength(1);

            int visibleTreesFound = 0;
            for (int x = 0; x < rows; x += 1)
            {
                for (int y = 0; y < columns; y += 1)
                {
                    if (_forest[x, y].IsSeen)
                    {
                        visibleTreesFound++;
                    }
                }
            }

            return visibleTreesFound;
        }

        private static bool IsVisibleOnEdge(int x, int y, Tree[,] forest, int rows, int columns)
        {
            return IsFirstOrLastRow(x, rows)
                   || IsFirstOrLastColumn(y, columns);
        }

        private static bool IsFirstOrLastRow(int x, int rows)
        {
            return x == 0 || x == rows - 1;
        }

        private static bool IsFirstOrLastColumn(int y, int columns)
        {
            return y == 0 || y == columns - 1;
        }

        public int FindHighestScenicScore()
        {
            var rows = _forest.GetLength(0);
            var columns = _forest.GetLength(1);
            int highestScore = 0;

            for (int x = 0; x < rows; x += 1)
            {
                for (int y = 0; y < columns; y += 1)
                {
                    if (_forest[x, y].ScenicScore > highestScore)
                    {
                        highestScore = _forest[x, y].ScenicScore;
                    }
                }
            }

            return highestScore;
        }
    }
}