using System;

namespace DRP.Core.Contracts.Issues.Views
{
    public class IssueView
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
