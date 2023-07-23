using System;
namespace NameSorter.Application.Services;

public class ParsingService : IParsingService
{
    public IEnumerable<Name> Parse(IEnumerable<string> names)
    {
        List<Name> result = new List<Name>();

        foreach (string name in names)
        {
            Name? parsedName = ParseName(name);
            if (parsedName != null)
                result.Add(parsedName);

        }

        return result;
    }

    public Name? ParseName(string nameString)
    {
        if (string.IsNullOrEmpty(nameString))
            return null;

        string[] nameParts = nameString.Trim().Split(" ");

        //Ignore multiple spaces and tabs
        nameParts = nameParts.Where(np => !string.IsNullOrEmpty(np)).ToArray();

        if (!IsValidName(nameParts))
            return null;

        string lastName = nameParts.Last();
        string[] givenNamesArray = nameParts.Take(nameParts.Length - 1).ToArray();
        string givenName = String.Join(" ", givenNamesArray);

        return new Name
        {
            LastName = lastName,
            GivenNames = givenName
        };
    }

    private bool IsValidName(string[] nameParts)
    {
        //Should have at least one given name and last name and 
        if (nameParts.Length < 2)
            return false;

        //Shoudld not have more than allowed number of given names
        if (nameParts.Length > Constants.MAX_GIVEN_NAMES_ALLOWED + 1)
            return false;

        return true;
    }
}