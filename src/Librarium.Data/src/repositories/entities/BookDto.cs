using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.infrastructure.repositories.dto;
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
}