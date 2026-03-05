using Domain.book;
using Domain.loan;
using Domain.member;
using Librarium.Data.infrastructure;
using Librarium.Data.repositories.entities;
using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;
using models.api_models;
using models.repositorycontracts;

namespace Librarium.Data.repositories;

public class LoansRepository(AppDbContext appDbContext) : ILoanRepository
{
    public async Task<IEnumerable<Loan>> GetLoansByMember(Guid memberId)
    {
        var rows = await appDbContext.Loans
            .Include(l => l.Member)
            .Include(l => l.Book)
            .Where(l => l.MemberId == memberId)
            .ToListAsync();

        return rows.Select(l => new Loan(
            new Member(new MemberId(l.Member!.MemberId), l.Member.FirstName, l.Member.LastName,
                new Email(l.Member.Email)),
            new Book(
                BookId.From(l.Book!.BookId),
                new InternationalStandardBookNumber(l.Book.Isbn),
                new BookTitle(l.Book.Title),
                new PublicationYear(l.Book.PublicationYear)),
            l.LoanDate));
    }

    public async Task<CreateLoanResponse> CreateLoan(CreateLoanDto request)
    {
        try
        {
            var loanEntity = new LoanEntity
            {
                LoanId = Guid.NewGuid(),
                MemberId = Guid.NewGuid(), // Should be resolved from request.MemberEmail lookup
                BookId = Guid.NewGuid(),   // Should be resolved from request.Isbn lookup
                LoanDate = request.LoanDate,
                ReturnDate = request.ReturnDate
            };
            await appDbContext.Loans.AddAsync(loanEntity);
            await appDbContext.SaveChangesAsync();
            return new CreateLoanResponse(true);
        }
        catch (Exception)
        {
            return new CreateLoanResponse(false);
        }
    }
}