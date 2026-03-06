namespace Librarium.Data.repositories.entities;

public class LoanEntity
{
    public Guid LoanId { get; set; }
    
    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    // Navigation properties
    public MemberDto? Member { get; set; }
    public BookDto? Book { get; set; }
}
