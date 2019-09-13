using AutoMapper;
using DRP.Core.Backend.Issues.Handlers;
using DRP.Core.Backend.Issues.Mappings;
using DRP.Core.Contracts.Issues.Commands;
using DRP.Core.Contracts.Issues.Queries;
using DRP.Core.Contracts.Issues.Views;
using DRP.Core.CQRS.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DRP.Core.Backend
{
    public class BackendModule : Module
    {
        public BackendModule()
        { }

        public override void Configure(IServiceCollection services)
        {
            services.AddValidators();

            RegisterHandlers(services);
            ConfigurateMapper(services);

            base.Configure(services);
        }

        public override void Use()
        {
            base.Use();
        }

        private void ConfigurateMapper(IServiceCollection services)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<IssueMappings>());

            services.AddAutoMapper();
        }

        private void RegisterHandlers(IServiceCollection services)
        {
            #region register Issue
            services.RegisterCommandHandler<CreateIssue, IssueCommandHandler>();
            services.RegisterCommandHandler<UpdateIssue, IssueCommandHandler>();
            services.RegisterCommandHandler<DeleteIssue, IssueCommandHandler>();

            services.RegisterQueryHandler<GetIssue, IssueView, IssueQueryHandler>();
            services.RegisterQueryHandler<GetIssues, IReadOnlyList<IssueView>, IssueQueryHandler>();
            #endregion
        }
    }
}
