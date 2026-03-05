using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.infrastructure.repositories.dto;
public class MemberDto
{
    [Key]
    public Guid MemberId { get; set; }
    
    [NotNull]
    public string FirstName { get; set; }

    [NotNull]
    public string LastName { get; set; }

    [NotNull]
    public string Email { get; set; }
}
