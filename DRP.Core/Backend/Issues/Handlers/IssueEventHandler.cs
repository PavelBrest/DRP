using DRP.Core.Contracts.Issues.Events;
using DRP.Core.CQRS.Abstractions.Events;
using DRP.Core.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.Backend.Issues.Handlers
{
    internal class IssueEventHandler :
        IEventHandler<IssueCreated>,
        IEventHandler<IssueUpdated>,
        IEventHandler<IssueDeleted>
    {
        private readonly IFileLogger _logger;

        public IssueEventHandler(IFileLogger logger)
        {
            _logger = logger;
        }

        public Task Handle(IssueCreated @event, CancellationToken cancellationToken)
        {
            _logger.Log($"{DateTime.Now} : IssueCreated Id : {@event.IssueId}");

            return Task.CompletedTask;
        }

        public Task Handle(IssueUpdated @event, CancellationToken cancellationToken)
        {
            _logger.Log($"{DateTime.Now} : IssueUpdated Id : {@event.IssueId}");

            return Task.CompletedTask;
        }

        public Task Handle(IssueDeleted @event, CancellationToken cancellationToken)
        {
            _logger.Log($"{DateTime.Now} : IssueDeleted Id : {@event.IssueId}");

            return Task.CompletedTask;
        }
    }
}
