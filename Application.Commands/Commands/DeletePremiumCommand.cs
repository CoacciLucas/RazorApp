using Application.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Commands;

public class DeletePremiumCommand : ICommand
{
    public DeletePremiumCommand(Guid id) => Id = id;
    public Guid Id { get; set; }
}
