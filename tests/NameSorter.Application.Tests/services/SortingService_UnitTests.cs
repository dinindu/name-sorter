using NameSorter.Application.Services;
namespace NameSorter.Application.Tests;

public class SortingService_UnitTests
{
    #region Sort Unit Tests

    [Fact]
    public void Sort_Should_SortByLastName()
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
    public void Sort_Should_SortByLastName_When_FirstCharacterIsTheSame()
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
    public void Sort_Should_SortByLastName_When_SameGivenNames()
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
    public void Sort_Should_SortByLastName_When_UpperCase()
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
    public void Sort_Should_SortByLastName_When_LowerCase()
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
    public void Sort_Should_SortByGivenNames_When_SameLastName()
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
    public void Sort_Should_SortByLastName_Then_ByGivenNames()
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
    public void Sort_Should_SortByGivenNames_InOrder()
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
    public void Sort_Should_SortByGivenNamesInOrder_When_MoreThanTwoGivenNames()
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
    public void Sort_Should_SortByGivenNamesInOrder_When_GivenNameCountsDiffer()
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

    #endregion
}