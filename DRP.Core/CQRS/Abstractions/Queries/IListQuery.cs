using MediatR;
using System.Collections.Generic;

namespace DRP.Core.CQRS.Abstractions.Queries
{
    public interface IListQuery<out Tout> : IQuery<IReadOnlyList<Tout>>, IRequest<IReadOnlyList<Tout>>
    { }
}
