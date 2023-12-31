using System.IO;
namespace NameSorter.Infrastructure;

public class FileReader : IFileReader
{
    /// <summary>
    /// ReadLines reads all lines from the specified file.
    /// Returns a list of string.
    /// </summary>
    public IEnumerable<string> ReadLines(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new Exception($"file not found: '{filename}'");
        }

        return File.ReadAllLines(filename);
    }
}
