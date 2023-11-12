namespace Application.Reads.DTOs;

public class PremiumDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StudentDTO? Student { get; set; }
}
