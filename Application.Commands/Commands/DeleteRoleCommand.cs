using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class DeleteRoleCommand : ICommand
{
    public DeleteRoleCommand(Guid id) => Id = id;
    public Guid Id { get; set; }
}
