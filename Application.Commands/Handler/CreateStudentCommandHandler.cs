using Application.Commands.Notification;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using RazorApp.Application.Commands;

namespace Application.Commands.Handler
{
    public class CreateStudentCommandHandler : CommandHandler, IRequestHandler<CreateStudentCommand, CommandResult>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork,
            IMediator mediator,
            INotificationHandler<NotificationDomainT> notification,
            ILogger<CommandHandler> logger,
            IStudentRepository studentRepository)
            : base(unitOfWork, mediator, notification, logger)
        {
            _studentRepository = studentRepository;
        }

        public async Task<CommandResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(2);

            student
                .SetName(request.Name)
                .SetEmail(request.Email);

            await _studentRepository.UpdateAsync(student);

            if (!IsSuccess())
                return new CommandResult(false);

            await CommittAsync();

            return new CommandResult(true);
        }
    }

}
