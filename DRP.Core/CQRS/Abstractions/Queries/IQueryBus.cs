using System.Threading.Tasks;

namespace DRP.Core.CQRS.Abstractions.Queries
{
    public interface IQueryBus
    {
        Task<Tout> Send<TQuery, Tout>(TQuery query)
            where TQuery : IQuery<Tout>;
    }
}
