using MediatR;

namespace DRP.Core.CQRS.Abstractions.Commands
{
    public interface ICommand : IRequest<Unit>
    { }
}
