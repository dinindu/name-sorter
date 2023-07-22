namespace NameSorter.Application.Services;

public class SortingService : ISortingService
{
    public IEnumerable<Name> Sort(IEnumerable<Name> persons)
    {
        return persons
            .OrderBy(p => p.LastName)
            .ThenBy(p => p.GivenNames)
            .AsEnumerable();
    }
}
