using System;
using System.ComponentModel;
using NameSorter.Infrastructure;
using NameSorter.Domain;
using NameSorter.Application.Services;
using CommandLine;
using CommandLine.Text;
using Serilog;

namespace NameSorter.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        ConfigureLogger();

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                try
                {
                    string inputFile = options.InputFile;
                    string outputFile = options.OutputFile;

                    string startLog = $"Sorting names from '{inputFile}' to '{outputFile}' ...";
                    Log.Information(startLog);

                    IEnumerable<string> sortedNameStrings = InitiateSorting(inputFile, outputFile);

                    DisplaySortedNames(sortedNameStrings);

                    string endLog = $"Sorted names from '{inputFile}' int to '{outputFile}'";
                    Log.Information(endLog);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"""
                                           Failed to sort names!
                                           Error(s):
                                           {ex.Message}
                                           """;
                    Console.WriteLine(errorMessage);
                    Log.Error(errorMessage);
                }
            });
    }

    private static IEnumerable<string> InitiateSorting(string inputFile, string outputFile)
    {
        IFileReader fileReader = new FileReader();
        IEnumerable<string> unsortedNameStrings = fileReader.ReadLines(inputFile);

        IParsingService parsingService = new ParsingService();
        IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(unsortedNameStrings);

        ISortingService sortingService = new SortingService();
        IEnumerable<Name> sortedNames = sortingService.Sort(parsedNames);

        IEnumerable<string> sortedNameStrings = parsingService.ParseToStringList(sortedNames);

        IFileWriter fileWriter = new FileWriter();
        fileWriter.WriteLines(outputFile, sortedNameStrings);

        return sortedNameStrings;
    }

    private static void DisplaySortedNames(IEnumerable<string> sortedNameStrings)
    {
        foreach (string name in sortedNameStrings)
        {
            Console.WriteLine(name);
        }
    }

    private static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("./logs/log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
    }
}
