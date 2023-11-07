namespace Application.Reads.DTOs;

public class StudentDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
