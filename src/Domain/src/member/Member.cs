using Error_definitions;

namespace Domain.member;

public class Member
{
    public MemberId MemberId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public Email Email { get; }
    
    public Member(MemberId memberId,string firstName, string lastName, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new MemberInvalid("First name cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new MemberInvalid("Last name cannot be null or empty.");
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email;
        MemberId =memberId;
    }
}