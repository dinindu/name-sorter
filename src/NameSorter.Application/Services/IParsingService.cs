namespace NameSorter.Application.Services;

public interface IParsingService
{
    Name? ParseToName(string nameString);
}
