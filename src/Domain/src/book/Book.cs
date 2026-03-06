

using Domain.author;
using Error_definitions;

namespace Domain.book;

public class Book
{
    public BookId BookId { get; set; }
    public InternationalStandardBookNumber Isbn { get; }
    public BookTitle Title { get; }
    public PublicationYear PublicationYear { get; }
    private readonly List<Author> _authors = new();
    public IReadOnlyList<Author> Authors => _authors.AsReadOnly();


    public Book(BookId bookId ,InternationalStandardBookNumber isbn, BookTitle title, PublicationYear publicationYear,List<Author> authors)
    {
        if (isbn == null)
            throw new BookInvalid("ISBN cannot be null.");
        if (title == null)
            throw new BookInvalid("Title cannot be null.");
        if (publicationYear == null)
            throw new BookInvalid("Publication year cannot be null.");
        Isbn = isbn;
        Title = title;
        PublicationYear = publicationYear;
        BookId = bookId;
        _authors.AddRange(authors);
    }
    
    public void AddAuthor(Author author)
    {
        if (author == null)
            throw new BookInvalid("Author cannot be null.");
        if (_authors.Any(a => a.Id == author.Id))
            throw new BookInvalid("Author is already associated with this book.");

        _authors.Add(author);
    }

    public void RemoveAuthor(Author author)
    {
        if (author == null)
            throw new BookInvalid("Author cannot be null.");

        _authors.Remove(author);
    }
  
    

    public override string ToString() => $"{Title} (ISBN: {Isbn}, Year: {PublicationYear})";
}