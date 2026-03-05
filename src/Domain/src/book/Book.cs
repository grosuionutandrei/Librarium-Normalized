

using Error_definitions;

namespace Domain.book;

public class Book
{
    public BookId BookId { get; set; }
    public InternationalStandardBookNumber Isbn { get; }
    public BookTitle Title { get; }
    public PublicationYear PublicationYear { get; }


    public Book(BookId bookId ,InternationalStandardBookNumber isbn, BookTitle title, PublicationYear publicationYear)
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
    }
    
    
  
    

    public override string ToString() => $"{Title} (ISBN: {Isbn}, Year: {PublicationYear})";
}