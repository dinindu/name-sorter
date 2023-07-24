namespace NameSorter.Application.Services;

public interface IParsingService
{
    IEnumerable<Name> ParseToNamesList(IEnumerable<string> names);
    Name? ParseName(string nameString);
    IEnumerable<string> ParseToStringList(IEnumerable<Name> names);
}
