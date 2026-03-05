

using Domain.member;


namespace Librarium.Services.application_services.ports;

public interface IMemberRepository
{
    Task <IEnumerable<Member>> GetAllMembers();
}