using Domain.Entities.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Premium : Entity
{
    [Required(ErrorMessage = "Informe o título do Premium!")]
    [StringLength(80, ErrorMessage = "O título deve conter até 80 caracteres!")]
    [MinLength(5, ErrorMessage = "O título deve conter pelo menos 5 caracteres!")]
    [DisplayName("Título")]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    [DisplayName("Início")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayName("Término")]
    public DateTime EndDate { get; set; }

    [DisplayName("Aluno")]
    [Required(ErrorMessage = "Aluno inválido")]
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
}
