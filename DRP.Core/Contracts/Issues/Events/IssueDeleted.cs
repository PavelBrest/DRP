using DRP.Core.CQRS.Abstractions.Events;
using System;

namespace DRP.Core.Contracts.Issues.Events
{
    internal class IssueDeleted : IEvent
    {
        public IssueDeleted(Guid issueId)
        {
            IssueId = issueId;
        }

        public Guid IssueId { get; }
    }
}
