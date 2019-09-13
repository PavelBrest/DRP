using DRP.Core.CQRS.Abstractions.Queries;
using MediatR;
using System.Threading.Tasks;

namespace DRP.Core.CQRS
{
    sealed class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }


        public Task<Tout> Send<TQuery, Tout>(TQuery query) 
            where TQuery : IQuery<Tout>
        {
            return _mediator.Send(query);
        }
    }
}
