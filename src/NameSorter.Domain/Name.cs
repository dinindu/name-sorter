namespace NameSorter.Domain;

public class Name
{
    public required string LastName { get; set; }
    public required string GivenNames { get; set; }

    public string DisplayName()
    {
        return $"{GivenNames} {LastName}";
    }
}
