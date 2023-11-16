using Application.Commands.Commands;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class CreateRoleCommandHandler : CommandHandler, IRequestHandler<CreateRoleCommand, CommandResult>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        RoleManager<IdentityRole> roleManager)
        : base(unitOfWork, mediator, logger)
    {
        _roleManager = roleManager;
    }

    public async Task<CommandResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new IdentityRole(request.Name);

        await _roleManager.CreateAsync(role);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }
}
