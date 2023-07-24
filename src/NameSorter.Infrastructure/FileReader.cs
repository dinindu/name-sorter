using System.IO;
namespace NameSorter.Infrastructure;

public class FileReader : IFileReader
{
    public IEnumerable<string> ReadLines(string filename)
    {

        if (!File.Exists(filename))
        {
            throw new Exception($"file not found: '{filename}'");
        }

        return File.ReadAllLines(filename);
    }
}
