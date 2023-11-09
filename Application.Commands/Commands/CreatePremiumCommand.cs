using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class CreatePremiumCommand : ICommand
{
    public CreatePremiumCommand(string title, DateTime startDate, DateTime endDate, Guid studentId)
    {
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        StudentId = studentId;
    }

    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid StudentId { get; set; }
}
