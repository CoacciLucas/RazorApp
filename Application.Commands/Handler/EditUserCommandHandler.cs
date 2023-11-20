using Application.Commands.Commands;
using Domain.Services.Interfaces;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public class EditUserCommandHandler : CommandHandler, IRequestHandler<EditUserCommand, CommandResult>
{
    private readonly IUserService _userService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IAspNetRoleService _roleService;
    public EditUserCommandHandler(IUnitOfWork unitOfWork,
        IMediator mediator,
        ILogger<CommandHandler> logger,
        IUserService userService,
        UserManager<IdentityUser> userManager,
        IAspNetRoleService roleService)
        : base(unitOfWork, mediator, logger)
    {
        _userService = userService;
        _userManager = userManager;
        _roleService = roleService;
    }

    public async Task<CommandResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsync(request.Id.ToString());
        var currentRoles = await _userManager.GetRolesAsync(user);
        var roles = new List<string>();
        foreach (var role in request.Roles)
        {
            var roleManager = await _roleService.GetByIdAsync(role.ToString());
            roles.Add(roleManager.Name);
        }

        var rolesToAdd = roles.Except(currentRoles).ToList();
        var rolesToRemove = currentRoles.Except(roles).ToList();

        if (rolesToRemove.Any())
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

        if(rolesToAdd.Any())
            await _userManager.AddToRolesAsync(user, rolesToAdd);



        user.UserName = request.UserName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;

        await _userManager.UpdateAsync(user);

        await _uow.CommitAsync();

        return new CommandResult(true);
    }
}
