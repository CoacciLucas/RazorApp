using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class EditRoleCommand : ICommand
{
    public EditRoleCommand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}
