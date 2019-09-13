using DRP.Core.CQRS.Abstractions.Commands;
using FluentValidation;
using System;

namespace DRP.Core.Contracts.Issues.Commands
{
    public class UpdateIssue : ICommand
    {
        public UpdateIssue(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
    }

    public class UpdateIssueValidator : AbstractValidator<UpdateIssue>
    {
        public UpdateIssueValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Title).NotEmpty();
        }
    }
}
