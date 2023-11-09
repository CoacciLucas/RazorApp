using Application.Commands.Commands;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class CreatePremiumCommandHandler : CommandHandler, IRequestHandler<CreatePremiumCommand, CommandResult>
{
    private readonly IPremiumRepository _premiumRepository;

    public CreatePremiumCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IPremiumRepository premiumRepository)
        : base(unitOfWork, mediator, logger)
    {
        _premiumRepository = premiumRepository;
    }

    public async Task<CommandResult> Handle(CreatePremiumCommand request, CancellationToken cancellationToken)
    {
        var student = new Premium(request.Title, request.StartDate, request.EndDate, request.StudentId);

        await _premiumRepository.AddAsync(student);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }
}
