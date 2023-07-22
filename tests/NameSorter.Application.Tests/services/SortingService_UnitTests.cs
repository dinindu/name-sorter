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

    [Fact]
    public void Sort_ShouldSortByLastNameWhenFirstCharacterIsTheSame()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "D",
            LastName = "AC"
        };

        Name name2 = new Name()
        {
            GivenNames = "E",
            LastName = "AB"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByLastNameWithSameGivenNames()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "Ghi",
            LastName = "Def"
        };

        Name name2 = new Name()
        {
            GivenNames = "Ghi",
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

    [Fact]
    public void Sort_ShouldSortByLastNameWithUpperCase()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "Abc",
            LastName = "DEF"
        };

        Name name2 = new Name()
        {
            GivenNames = "Def",
            LastName = "ABC"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByLastNameWithLowerCase()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "Abc",
            LastName = "def"
        };

        Name name2 = new Name()
        {
            GivenNames = "Def",
            LastName = "abc"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByGivenNamesWithSameLastName()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "Def",
            LastName = "Xyz"
        };

        Name name2 = new Name()
        {
            GivenNames = "Abc",
            LastName = "Xyz"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByLastNameThenByGivenNames()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "E",
            LastName = "B"
        };

        Name name2 = new Name()
        {
            GivenNames = "D",
            LastName = "A"
        };

        Name name3 = new Name()
        {
            GivenNames = "C",
            LastName = "A"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2, name3 };

        IEnumerable<Name> expectedNames = new List<Name>() { name3, name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByGivenNamesInOrder()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "B D",
            LastName = "A"
        };

        Name name2 = new Name()
        {
            GivenNames = "B C",
            LastName = "A"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByGivenNamesInOrderWhenMoreThanTwoGivenNames()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "B C E",
            LastName = "A"
        };

        Name name2 = new Name()
        {
            GivenNames = "B C D",
            LastName = "A"
        };

        IEnumerable<Name> unsortedNames = new List<Name>() { name1, name2 };

        IEnumerable<Name> expectedNames = new List<Name>() { name2, name1 };

        ISortingService sortingService = new SortingService();

        //Act
        IEnumerable<Name> result = sortingService.Sort(unsortedNames);

        //Assert
        result.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void Sort_ShouldSortByGivenNamesInOrderWithDifferentGivenNameCounts()
    {
        //Arrange
        Name name1 = new Name
        {
            GivenNames = "B C",
            LastName = "A"
        };

        Name name2 = new Name()
        {
            GivenNames = "B",
            LastName = "A"
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