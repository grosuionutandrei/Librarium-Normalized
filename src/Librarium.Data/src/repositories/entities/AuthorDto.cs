using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.repositories.entities;

public class AuthorDto
{
    [Key]
    public Guid AuthorId { get; set; }
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    public string? Biography { get; set; }

    public ICollection<BookDto> BooksDto { get; set; }
}