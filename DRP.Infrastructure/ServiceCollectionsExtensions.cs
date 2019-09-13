using DRP.Core.Data.Abstractions;
using DRP.Infrastructure.ORM;
using Microsoft.Extensions.DependencyInjection;

namespace DRP.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddReadonlyRepository<TEntity>(this IServiceCollection services)
            where TEntity : class, IHasId
        {
            services.AddTransient<IReadonlyRepository<TEntity>, ReadonlyRepository<TEntity>>();

            return services;
        }

        public static IServiceCollection AddRepository<TEntity>(this IServiceCollection services)
            where TEntity : class, IHasId
        {
            services.AddTransient<IRepository<TEntity>, Repository<TEntity>>();

            return services;
        }
    }
}
