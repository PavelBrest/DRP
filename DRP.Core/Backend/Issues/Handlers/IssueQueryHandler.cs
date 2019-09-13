using DRP.Core.Backend.Decorators;
using DRP.Core.Contracts.Issues.Queries;
using DRP.Core.Contracts.Issues.Views;
using DRP.Core.CQRS;
using DRP.Core.CQRS.Abstractions.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.Backend.Issues.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<GetIssue, IssueView>))]
    internal class IssueQueryHandler :
        IQueryHandler<GetIssue, IssueView>,
        IQueryHandler<GetIssues, IReadOnlyList<IssueView>>
    {
        public Task<IssueView> Handle(GetIssue request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new IssueView());
        }

        public Task<IReadOnlyList<IssueView>> Handle(GetIssues request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IReadOnlyList<IssueView>)new List<IssueView>().AsReadOnly());
        }
    }
}
