namespace models.api_models;
public record LoanDto(
    string BookIsbn,
    DateTime LoanDate,
    DateTime? ReturnDate);

public record LoanWithStatusDto(
    string BookIsbn,
     string BookTitle,
    DateTime LoanDate,
    DateTime? ReturnDate,
    string LoanStatus);
