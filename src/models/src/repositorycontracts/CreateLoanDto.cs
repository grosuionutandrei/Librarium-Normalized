

namespace models.repositorycontracts;

public record CreateLoanDto(Guid MemberId, Guid BookId,DateTime LoanDate,  DateTime? ReturnDate);


