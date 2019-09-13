using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.CQRS.Abstractions.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command, CancellationToken token = default) 
            where TCommand : ICommand;
    }
}
