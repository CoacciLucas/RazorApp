using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Application.Commands;

namespace Application.Commands.Handler
{
    public class CreateStudentCommandHandler : CommandHandler, IRequestHandler<CreateStudentCommand, CommandResult>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork,
            IMediator mediator,
            ILogger<CommandHandler> logger,
            IStudentRepository studentRepository)
            : base(unitOfWork, mediator, logger)
        {
            _studentRepository = studentRepository;
        }

        public async Task<CommandResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Name, request.Email);

            await _studentRepository.AddAsync(student);

            await _uow.CommitAsync();

            return new CommandResult(true);
        }
    }

}
