using DRP.Core.Contracts.Issues.Views;
using DRP.Core.CQRS.Abstractions.Queries;

namespace DRP.Core.Contracts.Issues.Queries
{
    public class GetIssues : IListQuery<IssueView>
    { }
}
