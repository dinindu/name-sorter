using NameSorter.Application.Services;
namespace NameSorter.Application.Tests;

public class SortingService_UnitTests
{
    [Fact]
    public void Sort_ShouldSortByLastName()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "Abc",
            LastName = "Def"
        };

        Name name2 = new Name()
        {
            GivenNames = "Def",
            LastName = "Abc"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);

    }
}