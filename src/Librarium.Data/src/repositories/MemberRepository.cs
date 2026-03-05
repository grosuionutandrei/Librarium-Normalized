using Domain.member;
using Librarium.Data.infrastructure;
using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;
namespace Librarium.Data.repositories;

public class MemberRepository(AppDbContext dbContext):IMemberRepository
{
    public async Task<IEnumerable<Member>> GetAllMembers()
    {

        return await dbContext.Members
            .Select(m => new Member(
                new MemberId(m.MemberId),
                m.FirstName,
                m.LastName,
                new Email(m.Email)))
            .ToListAsync();
    }
    
}