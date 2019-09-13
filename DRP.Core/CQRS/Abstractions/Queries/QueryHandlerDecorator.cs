using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.CQRS.Abstractions.Queries
{
    public abstract class QueryHandlerDecorator<TQuery, Tout>
        : IPipelineBehavior<TQuery, Tout>
        where TQuery : IQuery<Tout>
    {
        public abstract Task<Tout> Handle(TQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next);
    }
}
