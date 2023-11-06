using Application.Commands.Notification;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using RazorApp.Application.Commands;

namespace Application.Commands.Handler;

public class EditStudentCommandHandler : CommandHandler, IRequestHandler<EditStudentCommand, CommandResult>
{
    private readonly IStudentRepository _studentRepository;

    public EditStudentCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        INotificationHandler<NotificationDomainT> notification,
        ILogger<CommandHandler> logger,
        IStudentRepository studentRepository)
        : base(unitOfWork, mediator, notification, logger)
    {
        _studentRepository = studentRepository;
    }

    public async Task<CommandResult> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);
        if (student == null)
            AddNotification("Student", "Student not found");

        if (!IsSuccess())
            return new CommandResult(false);

        student
            .SetName(request.Name)
            .SetEmail(request.Email);

        await _studentRepository.UpdateAsync(student);

        await CommittAsync();

        return new CommandResult(true);
    }
}
