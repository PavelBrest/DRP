using DRP.Core.CQRS.Abstractions.Events;
using System;

namespace DRP.Core.Contracts.Issues.Events
{
    public class IssueCreated : IEvent
    {
        protected IssueCreated()
        { }

        public IssueCreated(Guid issueId, string title, string description)
        {
            IssueId = issueId;
            Title = title;
            Description = description;
        }

        public Guid IssueId { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }
    }
}
