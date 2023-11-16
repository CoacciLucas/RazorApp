using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class CreateRoleCommand : ICommand
{
    public CreateRoleCommand(string name) => Name = name;
    public string Name { get; set; }
}
