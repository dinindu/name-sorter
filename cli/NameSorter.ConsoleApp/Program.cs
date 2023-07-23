using NameSorter.Infrastructure;
using NameSorter.Domain;
using NameSorter.Application.Services;

namespace NameSorter.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "./unsorted-names-list.txt";

        IFileReader fileReader = new FileReader();
        IEnumerable<string> unsortedNames = fileReader.ReadLines(inputFile);

        IParsingService parsingService = new ParsingService();
        IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(unsortedNames);

        ISortingService sortingService = new SortingService();
        IEnumerable<Name> sortedNames = sortingService.Sort(parsedNames);

        IEnumerable<string> sortedNameStrings = parsingService.ParseToStringList(sortedNames);

        string outputFile = "./sorted-names-list.txt";

        IFileWriter fileWriter = new FileWriter();
        fileWriter.WriteLines(outputFile, sortedNameStrings);

        DisplaySortedNames(sortedNameStrings);

    }

    private static void DisplaySortedNames(IEnumerable<string> sortedNameStrings)
    {
        foreach (string name in sortedNameStrings)
        {
            Console.WriteLine(name);
        }
    }
}
