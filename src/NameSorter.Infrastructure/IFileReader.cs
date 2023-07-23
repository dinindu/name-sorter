namespace NameSorter.Infrastructure;

public interface IFileReader
{
    IEnumerable<string> ReadLines(string filename);
}