namespace models.api_models;

public record CreateLoanRequest(Guid MemberId, Guid BookId,DateTime? ReturnDate);
