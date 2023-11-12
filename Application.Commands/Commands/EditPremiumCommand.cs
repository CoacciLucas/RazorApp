using Application.Commands.Interface;

namespace Application.Commands.Commands;

public class EditPremiumCommand : ICommand
{
    public EditPremiumCommand(Guid id, string title, DateTime startDate, DateTime endDate, Guid studentId)
    {
        Id = id;
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        StudentId = studentId;
    }

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid StudentId { get; set; }
}
