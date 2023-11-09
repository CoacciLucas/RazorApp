using Application.Commands.Commands;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class DeleteStudentCommandHandler : CommandHandler, IRequestHandler<DeleteStudentCommand, CommandResult>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IStudentRepository studentRepository)
        : base(unitOfWork, mediator, logger)
    {
        _studentRepository = studentRepository;
    }

    public async Task<CommandResult> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);

        if (student == null)
            return new CommandResult(false, "Student not found");

        await _studentRepository.DeleteAsync(student);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }

}
