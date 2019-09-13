using DRP.Core.Backend.Issues;
using DRP.Core.CQRS.DependencyInjection;
using DRP.Core.Services.Abstractions;
using DRP.Infrastructure.Logger;

using Microsoft.Extensions.DependencyInjection;

namespace DRP.Infrastructure
{
    public class InfrastructureModule : Module
    {
        public InfrastructureModule()
        { }

        public override void Configure(IServiceCollection services)
        {
            ConfigureIntrastructure(services);
        }

        private void ConfigureIntrastructure(IServiceCollection services)
        {
            services.AddRepository<Issue>();
            services.AddReadonlyRepository<Issue>();

            services.AddSingleton<IFileLogger, FileLogger>();
        }
    }
}
