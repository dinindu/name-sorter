namespace NameSorter.Application.Services;

public class SortingService : ISortingService
{
    /// <summary>
    /// Sort takes in a list of Names and sort them by Last Name then by Given Name(s)
    /// Returns a sorted list of Names
    /// </summary>
    public IEnumerable<Name> Sort(IEnumerable<Name> names)
    {
        return names
            .OrderBy(n => n.LastName)
            .ThenBy(n => n.GivenNames)
            .AsEnumerable();
    }
}
