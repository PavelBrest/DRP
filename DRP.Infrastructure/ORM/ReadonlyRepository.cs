using DRP.Core.Data.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DRP.Infrastructure.ORM
{
    internal class ReadonlyRepository<TEntity> : IReadonlyRepository<TEntity>
        where TEntity : class, IHasId
    {
        public IQueryable<TEntity> CustomQuery(string query)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
