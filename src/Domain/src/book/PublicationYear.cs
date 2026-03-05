using Error_definitions;

namespace Domain.book;

public class PublicationYear
{
    public int Value { get; }

    private const int MinimumYear = 1440;
    
   
    private static int MaximumYear => DateTime.Now.Year + 10;

    public PublicationYear(int year)
    {
        if (year < MinimumYear || year > MaximumYear)
            throw new BookInvalid(
                $"Publication year must be between {MinimumYear} and {MaximumYear}.");

        Value = year;
    }

    public override string ToString() => Value.ToString();
    public override bool Equals(object? obj) => obj is PublicationYear other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}

