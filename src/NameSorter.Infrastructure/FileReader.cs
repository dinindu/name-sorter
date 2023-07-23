using System.IO;
namespace NameSorter.Infrastructure;

public class FileReader : IFileReader
{
    public IEnumerable<string> ReadLines(string filename)
    {
        return File.ReadAllLines(filename);
    }
}
