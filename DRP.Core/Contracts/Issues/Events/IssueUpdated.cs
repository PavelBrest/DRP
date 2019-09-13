using DRP.Core.CQRS.Abstractions.Events;
using System;

namespace DRP.Core.Contracts.Issues.Events
{
    public class IssueUpdated : IEvent
    {
        public IssueUpdated(Guid issueId, string title, string description)
        {
            IssueId = issueId;
            Title = title;
            Description = description;
        }

        public Guid IssueId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}
