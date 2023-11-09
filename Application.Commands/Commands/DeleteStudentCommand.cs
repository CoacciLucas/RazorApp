using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class DeleteStudentCommand : ICommand
{
    public DeleteStudentCommand(Guid id) => Id = id;
    public Guid Id { get; set; }
}
