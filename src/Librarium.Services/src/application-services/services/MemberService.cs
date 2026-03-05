using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.api_models;

namespace Librarium.Services.application_services.services;

public class MemberService(IMemberRepository memberRepository):IMemberService
{
    public  async  Task<List<MemberDto>> GetAllMembers()
    {

        var response = await memberRepository.GetAllMembers();
        return response.Select(m=>new MemberDto(m.MemberId.Id,m.FirstName,m.LastName,m.Email.ToString())).ToList();
    }
}