namespace Application.Reads.DTOs;

public class IdentityRoleDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }
}
