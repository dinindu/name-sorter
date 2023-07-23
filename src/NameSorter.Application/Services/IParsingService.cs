namespace NameSorter.Application.Services;

public interface IParsingService
{
    IEnumerable<Name> ParseToNames(IEnumerable<string> names);
    Name? ParseName(string nameString);
}
