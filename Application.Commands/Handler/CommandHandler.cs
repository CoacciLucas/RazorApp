using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public abstract class CommandHandler
{
    protected readonly IUnitOfWork _uow;

    protected readonly IMediator _mediator;

    protected readonly ILogger<CommandHandler> _logger;

    public CommandHandler()
    {
    }

    public CommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CommandHandler(IUnitOfWork uow, IMediator mediator)
    {
        _uow = uow;
        _mediator = mediator;
    }

    public CommandHandler(IUnitOfWork uow, IMediator mediator, ILogger<CommandHandler> logger = null)
    {
        _uow = uow;
        _mediator = mediator;
        _logger = logger;
    }
}
