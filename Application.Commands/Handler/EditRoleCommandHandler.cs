using Application.Commands.Commands;
using Domain.Services.Interfaces;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class EditRoleCommandHandler : CommandHandler, IRequestHandler<EditRoleCommand, CommandResult>
{
    private readonly IAspNetRoleService _roleService;
    private readonly RoleManager<IdentityRole> _roleManager;

    public EditRoleCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IAspNetRoleService roleService,
        RoleManager<IdentityRole> roleManager)
        : base(unitOfWork, mediator, logger)
    {
        _roleService = roleService;
        _roleManager = roleManager;
    }

    public async Task<CommandResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleService.GetByIdAsync(request.Id.ToString());
        if (role == null)
            throw new KeyNotFoundException(nameof(role));

        role.Name = request.Name;
        await _roleManager.UpdateAsync(role);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }
}
