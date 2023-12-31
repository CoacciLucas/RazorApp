﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace RazorApp.Attribute;

public class ClaimRequirementFilter : IAuthorizationFilter
{
    private readonly Claim _claim;

    public ClaimRequirementFilter(Claim claim) => _claim = claim;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User.Identity as ClaimsPrincipal;

        if (user == null || !user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!user.HasClaim(_claim.Type, _claim.Value))
            context.Result = new ForbidResult();
    }
}
