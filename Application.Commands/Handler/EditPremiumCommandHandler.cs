using Application.Commands.Commands;
using Domain.Services.Interfaces;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class EditPremiumCommandHandler : CommandHandler, IRequestHandler<EditPremiumCommand, CommandResult>
{
    private readonly IPremiumService _premiumService;

    public EditPremiumCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IPremiumService premiumService)
        : base(unitOfWork, mediator, logger)
    {
        _premiumService = premiumService;
    }

    public async Task<CommandResult> Handle(EditPremiumCommand request, CancellationToken cancellationToken)
    {
        var premium = await _premiumService.GetByIdAsync(request.Id);

        premium
            .SetTitle(request.Title)
            .SetStartDate(request.StartDate)
            .SetEndDate(request.EndDate)
            .SetStudent(request.StudentId);

        await _premiumService.UpdateAsync(premium);
        await _uow.CommitAsync();

        return new CommandResult(true);
    }
}
