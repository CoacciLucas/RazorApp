using Domain.Entities.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Premium : Entity
{
    [Required(ErrorMessage = "Please inform the Premium title!")]
    [StringLength(80, ErrorMessage = "The title should have up to 80 caracteres!")]
    [MinLength(5, ErrorMessage = "The title should have at least 5 caracteres!")]
    [DisplayName("Title")]
    public string Title { get; private set; } = string.Empty;

    public Premium(string title, DateTime startDate, DateTime endDate, Guid studentId)
    {
        Title = title;
        StartDate = startDate;
        EndDate = endDate;
        StudentId = studentId;
    }
    public Premium() { }

    [DataType(DataType.DateTime)]
    [DisplayName("Start")]
    public DateTime StartDate { get; private set; }

    [DataType(DataType.DateTime)]
    [DisplayName("End")]
    public DateTime EndDate { get; private set; }

    [DisplayName("Student")]
    [Required(ErrorMessage = "Invalid Student")]
    public Guid StudentId { get; private set; }
    public Student? Student { get; private set; }

    public Premium SetTitle(string title)
    {
        Title = title;
        return this;
    }
    public Premium SetStartDate(DateTime startDate)
    {
        StartDate = startDate;
        return this;
    }
    public Premium SetEndDate(DateTime endDate)
    {
        EndDate = endDate;
        return this;
    }
    public Premium SetStudent(Guid studentId)
    {
        StudentId = studentId;
        return this;
    }
}
