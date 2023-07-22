namespace NameSorter.Application.Tests;

public class SortingService_UnitTests
{
    [Fact]
    public void Sort_ShouldSortByLastName()
    {
        //Arrange
        Person person1 = new Person()
        {
            GivenName = "Abc",
            LastName = "Def"
        };

        Person person2 = new Person()
        {
            GivenName = "Def",
            LastName = "Abc"
        };

        IEnumerable<Person> unsortedPersons = new List<Person>() { person1, person2 };

        IEnumerable<Person> expectedPersons = new List<Person>() { person2, person1 };


        //Act
        IEnumerable<Person> result = sortingService.Sort(persons);

        //Assert
        result.Count.ShouldBe(expectedPersons.Count);

    }
}