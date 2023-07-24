using System;
using System.ComponentModel;
using NameSorter.Infrastructure;
using NameSorter.Domain;
using NameSorter.Application.Services;
using CommandLine;
using CommandLine.Text;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace NameSorter.ConsoleApp;

class Program
{
    private readonly IFileReader _fileReader;
    private readonly IParsingService _parsingService;
    private readonly ISortingService _sortingService;
    private readonly IFileWriter _fileWriter;

    public Program(IFileReader fileReader, IParsingService parsingService, ISortingService sortingService, IFileWriter fileWriter)
    {
        _fileReader = fileReader;
        _parsingService = parsingService;
        _sortingService = sortingService;
        _fileWriter = fileWriter;
    }
    static void Main(string[] args)
    {
        ConfigureLogger();

        var serviceProvider = ConfigureServiceProvider();

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                var program = new Program(
                        serviceProvider.GetService<IFileReader>(),
                        serviceProvider.GetService<IParsingService>(),
                        serviceProvider.GetService<ISortingService>(),
                        serviceProvider.GetService<IFileWriter>());

                program.Run(options);
            });
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

    private static ServiceProvider ConfigureServiceProvider()
    {
        return new ServiceCollection()
            .AddSingleton<IFileReader, FileReader>()
            .AddSingleton<IParsingService, ParsingService>()
            .AddSingleton<ISortingService, SortingService>()
            .AddSingleton<IFileWriter, FileWriter>()
            .BuildServiceProvider();
    }

    private void Run(Options options)
    {
        try
        {
            string inputFile = options.InputFile;
            string outputFile = options.OutputFile;

            string startLog = $"Sorting names from '{inputFile}' in to '{outputFile}' ...";
            Log.Information(startLog);

            IEnumerable<string> sortedNameStrings = InitiateSorting(inputFile, outputFile);

            DisplaySortedNames(sortedNameStrings);

            string endLog = $"Sorted names from '{inputFile}' int to '{outputFile}'.";
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
    }

    private IEnumerable<string> InitiateSorting(string inputFile, string outputFile)
    {
        IEnumerable<string> unsortedNameStrings = _fileReader.ReadLines(inputFile);

        IEnumerable<Name> parsedNames = _parsingService.ParseToNamesList(unsortedNameStrings);

        IEnumerable<Name> sortedNames = _sortingService.Sort(parsedNames);

        IEnumerable<string> sortedNameStrings = _parsingService.ParseToStringList(sortedNames);

        _fileWriter.WriteLines(outputFile, sortedNameStrings);

        return sortedNameStrings;
    }

    private static void DisplaySortedNames(IEnumerable<string> sortedNameStrings)
    {
        foreach (string name in sortedNameStrings)
        {
            Console.WriteLine(name);
        }
    }
}
