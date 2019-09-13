using DRP.Core.CQRS.Abstractions.Commands;
using FluentValidation;

namespace DRP.Core.Contracts.Issues.Commands
{
    public class CreateIssue : ICommand
    {
        public CreateIssue(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }
        public string Description { get; }
    }

    public class CreateIssueValidator : AbstractValidator<CreateIssue>
    {
        public CreateIssueValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
        }
    }
}
