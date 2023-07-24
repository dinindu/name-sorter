using CommandLine;
using CommandLine.Text;

namespace NameSorter.ConsoleApp;

public class Options
{
    [Option('i', "input", Required = true, HelpText = "Input file containing unsorted names.")]
    public string InputFile { get; set; }

    [Option('o', "output", Required = true, HelpText = "Output file to store sorted names.")]
    public string OutputFile { get; set; }
}
