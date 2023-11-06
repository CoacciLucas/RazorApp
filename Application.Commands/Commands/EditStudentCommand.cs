using Application.Commands.Interface;

namespace RazorApp.Application.Commands;

public class EditStudentCommand : ICommand
{
    public EditStudentCommand(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
