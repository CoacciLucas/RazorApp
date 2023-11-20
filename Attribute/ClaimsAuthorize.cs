using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RazorApp.Attribute;

public class ClaimsAuthorize : TypeFilterAttribute
{
    public ClaimsAuthorize(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter)) =>
        Arguments = new object[] { new Claim(claimType, claimValue) };
}

