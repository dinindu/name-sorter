using System.IO;
namespace NameSorter.Infrastructure;

public class FileWriter : IFileWriter
{
    /// <summary>
    /// WriteLines takes in a list of strings and writes them to the specified file
    /// </summary>
    public void WriteLines(string filename, IEnumerable<string> lines)
    {
        File.WriteAllLines(filename, lines);
    }
}
