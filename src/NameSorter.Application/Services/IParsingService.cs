namespace NameSorter.Application.Services;

public interface IParsingService
{
    IEnumerable<Name> Parse(IEnumerable<string> names);
    Name? ParseName(string nameString);
}
