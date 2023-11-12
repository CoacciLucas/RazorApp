using Application.Commands.Commands;
using Domain.Repositories;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class DeletePremiumCommandHandler : CommandHandler, IRequestHandler<DeletePremiumCommand, CommandResult>
{
    private readonly IPremiumRepository _premiumRepository;

    public DeletePremiumCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IPremiumRepository premiumRepository)
        : base(unitOfWork, mediator, logger)
    {
        _premiumRepository = premiumRepository;
    }

    public async Task<CommandResult> Handle(DeletePremiumCommand request, CancellationToken cancellationToken)
    {
        var premium = await _premiumRepository.GetByIdAsync(request.Id);

        if (premium == null)
            return new CommandResult(false, "Premium not found");

        await _premiumRepository.DeleteAsync(premium);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }

}
