using AutoMapper;
using DRP.Core.Contracts.Issues.Commands;
using DRP.Core.Contracts.Issues.Events;
using System;

namespace DRP.Core.Backend.Issues.Mappings
{
    internal class IssueMappings : Profile
    {
        public IssueMappings()
        {
            CreateMap<CreateIssue, Issue>()
                .ForMember(p => p.Id,
                    cfg => cfg.MapFrom(p => Guid.NewGuid()));
            CreateMap<Issue, IssueCreated>()
                .ForMember(p => p.IssueId,
                    cfg => cfg.MapFrom(p => p.Id));
        }
    }
}
