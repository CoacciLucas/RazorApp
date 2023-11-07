using Application.Commands.Interface;

namespace RazorApp.Application.Commands;

public class EditStudentCommand : ICommand
{
    public EditStudentCommand(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
