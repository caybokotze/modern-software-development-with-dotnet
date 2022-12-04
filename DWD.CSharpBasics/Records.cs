namespace CSharpBasics;


// this demonstrates an example of a immutable Person Details record.
public record PersonDetails(string Tel, int Age);

// alternatively you could write the same record like this.

public record VerbosePersonDetails
{
    public VerbosePersonDetails(string Tel, int Age)
    {
        this.Tel = Tel;
        this.Age = Age;
    }
    public string Tel { get; init; }
    public int Age { get; init; }
}

// the constructor is not required however...
public record VerbosePersonDetails2
{
    public string? Tel { get; init; }
    public int Age { get; init; }
}

// this behaves effectively the same as the immutable record.
public class PersonDetailsImmutableClass
{
    public string? Tel { get; init; }
    public int Age { get; init; }
}

// we can also define hybrid record / struct types
public record struct Coordinate(double X, double Y);

/* Key takeaways...
 * Records are more succinct than classes.
 * Both a class and a record are reference types.
 * Ideally used for entities (only to store data).
 * A good way to represent primitive data types that don't have a large amount of properties
 */