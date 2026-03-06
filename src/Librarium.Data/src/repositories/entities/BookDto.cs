using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.repositories.entities;
public class BookDto
{
    [Key]
    public Guid BookId { get; init; } 

    [NotNull]
    public required string Title { get; init; }
    
    [NotNull]
    public string Isbn { get; init; }
    [NotNull]
    public int PublicationYear { get; init; }
    public ICollection<AuthorDto> Authors { get; set; }
}