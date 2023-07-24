using System;
using System.ComponentModel;
using NameSorter.Infrastructure;
using NameSorter.Domain;
using NameSorter.Application.Services;
using CommandLine;
using CommandLine.Text;

namespace NameSorter.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                try
                {
                    string inputFile = options.InputFile;
                    string outputFile = options.OutputFile;

                    IFileReader fileReader = new FileReader();
                    IEnumerable<string> unsortedNames = fileReader.ReadLines(inputFile);

                    IParsingService parsingService = new ParsingService();
                    IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(unsortedNames);

                    ISortingService sortingService = new SortingService();
                    IEnumerable<Name> sortedNames = sortingService.Sort(parsedNames);

                    IEnumerable<string> sortedNameStrings = parsingService.ParseToStringList(sortedNames);

                    IFileWriter fileWriter = new FileWriter();
                    fileWriter.WriteLines(outputFile, sortedNameStrings);

                    DisplaySortedNames(sortedNameStrings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
    }

    private static void DisplaySortedNames(IEnumerable<string> sortedNameStrings)
    {
        foreach (string name in sortedNameStrings)
        {
            Console.WriteLine(name);
        }
    }
}
