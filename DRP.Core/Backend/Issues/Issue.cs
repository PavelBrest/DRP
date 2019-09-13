using DRP.Core.Data.Abstractions;
using System;

namespace DRP.Core.Backend.Issues
{
    public class Issue : IHasId<Guid>
    {
        public Issue()
        {  }

        public Issue(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; set; }

        object IHasId.Id => Id;

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
