using MediatR;

namespace DRP.Core.CQRS.Abstractions.Queries
{
    public interface IQueryHandler<in TQuery, Tout>
        : IRequestHandler<TQuery, Tout>
        where TQuery : IQuery<Tout>
    { }
}
