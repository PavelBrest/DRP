using DRP.Core.Contracts.Issues.Views;
using DRP.Core.CQRS.Abstractions.Queries;
using FluentValidation;
using System;

namespace DRP.Core.Contracts.Issues.Queries
{
    public class GetIssue : IQuery<IssueView>
    {
        public Guid Id { get; }

        public GetIssue(Guid id)
        {
            Id = id;
        }
    }

    public class GetIssueValidator : AbstractValidator<GetIssue>
    {
        public GetIssueValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
