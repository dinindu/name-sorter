using NameSorter.Domain;

namespace NameSorter.Application.Services;

public interface ISortingService
{
    IEnumerable<Name> Sort(IEnumerable<Name> names);
}
