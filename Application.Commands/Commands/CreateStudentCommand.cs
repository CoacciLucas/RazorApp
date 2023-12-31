﻿using Application.Commands.Interface;

namespace RazorApp.Application.Commands;

public class CreateStudentCommand : ICommand
{
    public CreateStudentCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
}
