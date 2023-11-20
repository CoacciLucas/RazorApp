using Application.Commands.Interface;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.Commands;

public class EditUserCommand : ICommand
{
    public EditUserCommand(Guid id, string userName, string email, string phoneNumber, List<Guid> roles)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PhoneNumber = phoneNumber;
        Roles = roles;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<Guid> Roles { get; set; } = new();
}
