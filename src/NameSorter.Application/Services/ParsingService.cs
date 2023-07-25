using System;
namespace NameSorter.Application.Services;

public class ParsingService : IParsingService
{
    /// <summary>
    /// ParseToNamesList converts a list of names in string format into a list of Name.
    /// </summary>
    public IEnumerable<Name> ParseToNamesList(IEnumerable<string> names)
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

    /// <summary>
    /// ParseName converts a string into a Name.
    /// Returns null if the string is empty or invalid.
    /// </summary>
    public Name? ParseName(string nameString)
    {
        if (string.IsNullOrEmpty(nameString))
            return null;

        string[] nameParts = nameString.Trim().Split(" ");

        //Ignore multiple spaces and tabs by removing empty name parts
        nameParts = nameParts.Where(np => !string.IsNullOrEmpty(np)).ToArray();

        if (!IsValidName(nameParts))
            return null;

        //Last name part is the last name
        string lastName = nameParts.Last();

        //Get the given names from the name parts
        string[] givenNamesArray = nameParts.Take(nameParts.Length - 1).ToArray();
        string givenName = String.Join(" ", givenNamesArray);

        return new Name
        {
            LastName = lastName,
            GivenNames = givenName
        };
    }

    /// <summary>
    /// ParseToNamesList converts a list of Name into a list of names in string format.
    /// </summary>
    public IEnumerable<string> ParseToStringList(IEnumerable<Name> names)
    {
        return names.Select(n => n.DisplayName()).ToList();
    }

    /// <summary>
    /// IsValidName validates a name considering the name parts.
    /// Returns true if the name is valid and false otherwise.
    /// </summary>
    private bool IsValidName(string[] nameParts)
    {
        //Should have at least one given name and last name 
        if (nameParts.Length < 2)
            return false;

        //Shoudld not have more than allowed number of given names
        if (nameParts.Length > Constants.MAX_GIVEN_NAMES_ALLOWED + 1)
            return false;

        return true;
    }
}