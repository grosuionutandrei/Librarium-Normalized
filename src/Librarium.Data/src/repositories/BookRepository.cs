using Domain.book;
using Librarium.Data.infrastructure;
using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;

namespace Librarium.Data.repositories;


public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books
            .Select(b => new Book(
                BookId.From(b.BookId),
                new InternationalStandardBookNumber(b.Isbn),
                new BookTitle(b.Title),
                new PublicationYear(b.PublicationYear)
            ))
            .ToListAsync();
    }
}

