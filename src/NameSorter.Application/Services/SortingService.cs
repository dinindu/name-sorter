namespace NameSorter.Application.Services;

public class SortingService : ISortingService
{
    public IEnumerable<Name> Sort(IEnumerable<Name> names)
    {
        return names
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.GivenNames)
            .AsEnumerable();
    }
}
