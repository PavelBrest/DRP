using Microsoft.Extensions.DependencyInjection;

namespace DRP.Core.CQRS.DependencyInjection.Abstractions
{
    public interface IModule
    {
        void Configure(IServiceCollection services);

        void Use();
    }
}
