using MediatR;

namespace DRP.Core.CQRS.Abstractions.Queries
{
    public interface IQuery<out Tout> : IRequest<Tout>
    { }
}
