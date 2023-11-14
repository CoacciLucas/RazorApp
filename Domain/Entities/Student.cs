using Domain.Entities.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Student : Entity
{
    public Student(string name, string email)
    {
        Name = name;
        Email = email;
    }
    public Student() { }

    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres!")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres!")]
    [DisplayName("Nome Completo")]
    public string Name { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Informe o E-mail!")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    [DisplayName("E-mail")]
    public string Email { get; private set; } = string.Empty;

    public List<Premium> Premiums { get; private set; } = new();

    public Student SetName(string name)
    {
        Name = name;
        return this;
    }

    public Student SetEmail(string email)
    {
        Email = email;
        return this;
    }
}
