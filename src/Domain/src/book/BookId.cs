namespace Domain.book;

public sealed class BookId : IEquatable<BookId>
{
    public Guid Value { get; }

    private BookId(Guid value)
    {
        Value = value;
    }

    public static BookId New() => new(Guid.NewGuid());

    public static BookId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("BookId cannot be empty or default GUID.", nameof(value));

        return new BookId(value);
    }

    public static BookId FromString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("BookId string cannot be null or empty.", nameof(value));

        if (!Guid.TryParse(value, out var guid))
            throw new ArgumentException("Invalid GUID format for BookId.", nameof(value));

        return From(guid);
    }

    public static bool TryParse(string? input, out BookId? bookId)
    {
        bookId = null;

        if (!Guid.TryParse(input, out var guid) || guid == Guid.Empty)
            return false;

        bookId = new BookId(guid);
        return true;
    }

    public override string ToString() => Value.ToString();

    public bool Equals(BookId? other) => other is not null && Value.Equals(other.Value);

    public override bool Equals(object? obj) => obj is BookId other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();

    public static bool operator ==(BookId? left, BookId? right) => Equals(left, right);

    public static bool operator !=(BookId? left, BookId? right) => !Equals(left, right);

    public static implicit operator Guid(BookId id) => id.Value;
}