using DRP.Core.CQRS.Abstractions.Commands;
using FluentValidation;
using System;

namespace DRP.Core.Contracts.Issues.Commands
{
    public class DeleteIssue : ICommand
    {
        public DeleteIssue(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class DeleteIssueValidator : AbstractValidator<DeleteIssue>
    {
        public DeleteIssueValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
