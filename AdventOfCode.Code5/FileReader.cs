using System.Reflection;

namespace AdventOfCode.Code1
{
    internal static class FileReader
    {

        public static IEnumerable<string> ReadLines(string fileName)
        {
            var filePath = Path.Combine(AssemblyDirectory, fileName);
            return File.ReadAllLines(filePath);
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
