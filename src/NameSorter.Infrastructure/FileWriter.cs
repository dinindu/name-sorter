using System.IO;

namespace NameSorter.Infrastructure
{
    public class FileWriter : IFileWriter
    {
        public bool WriteLines(string filename, IEnumerable<string> lines)
        {
            File.WriteAllLines(filename, lines);

            return true;
        }
    }
}