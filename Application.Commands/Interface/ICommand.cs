using MediatR;

namespace Application.Commands.Interface;

public interface ICommand : IRequest<CommandResult>, IBaseRequest
{
}
