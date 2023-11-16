using Application.Commands.Commands;
using Domain.Services.Interfaces;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class DeleteRoleCommandHandler : CommandHandler, IRequestHandler<DeleteRoleCommand, CommandResult>
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAspNetRoleService _roleService;
    public DeleteRoleCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        RoleManager<IdentityRole> roleManager,
        IAspNetRoleService roleService)
        : base(unitOfWork, mediator, logger)
    {
        _roleManager = roleManager;
        _roleService = roleService;
    }

    public async Task<CommandResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleService.GetByIdAsync(request.Id.ToString());

        if (role == null)
            return new CommandResult(false, "Role not found");

        await _roleManager.DeleteAsync(role);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }

}
