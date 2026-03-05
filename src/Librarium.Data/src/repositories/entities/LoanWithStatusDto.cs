using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace Librarium.Data.infrastructure.repositories.dto;

public class LoanWithStatusDto
{
    [NotNull]
    [MaxLength(255)]
    public string? MemberEmail { get; set; }

    [NotNull]
    [MaxLength(20)]
    public string? BookIsbn { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string LoanStatus { get; set; } = string.Empty;
    // Navigation properties
    public MemberDto? Member { get; set; }
    public BookDto? Book { get; set; }
    
}