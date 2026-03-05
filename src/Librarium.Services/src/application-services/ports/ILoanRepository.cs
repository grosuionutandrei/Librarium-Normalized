using Domain.loan;
using models.api_models;
using models.repositorycontracts;

namespace Librarium.Services.application_services.ports;

public interface ILoanRepository
{
Task <IEnumerable<Loan>> GetLoansByMember(Guid memberId);
Task <CreateLoanResponse> CreateLoan(CreateLoanDto request);

}