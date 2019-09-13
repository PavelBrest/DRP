using AutoMapper;
using DRP.Core.Contracts.Issues.Commands;
using DRP.Core.Backend.Decorators;
using DRP.Core.CQRS;
using DRP.Core.CQRS.Abstractions.Commands;
using DRP.Core.CQRS.Abstractions.Events;
using DRP.Core.Data.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DRP.Core.Contracts.Issues.Events;

namespace DRP.Core.Backend.Issues.Handlers
{
    [HandlerDecorator(typeof(ValidateRequestDecorator<CreateIssue, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<UpdateIssue, Unit>))]
    [HandlerDecorator(typeof(ValidateRequestDecorator<DeleteIssue, Unit>))]

    [HandlerDecorator(typeof(SecurityRequestDecorator<CreateIssue, Unit>))]
    [HandlerDecorator(typeof(SecurityRequestDecorator<DeleteIssue, Unit>))]
    public class IssueCommandHandler : 
        ICommandHandler<CreateIssue>,
        ICommandHandler<UpdateIssue>,
        ICommandHandler<DeleteIssue>
    {
        private readonly IEventBus _eventBus;
        private readonly IRepository<Issue> _repository;
        private readonly IMapper _mapper;

        public IssueCommandHandler(
            IEventBus eventBus, 
            IRepository<Issue> repository, 
            IMapper mapper)
        {
            _eventBus = eventBus ?? throw new ArgumentException(nameof(eventBus));
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<Unit> Handle(CreateIssue request, CancellationToken cancellationToken)
        {
            var issue = _mapper.Map<Issue>(request);
            await _repository.AddAsync(issue);

            var @event = _mapper.Map<IssueCreated>(issue);
            await _eventBus.Publish(@event);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateIssue request, CancellationToken cancellationToken)
        {
            var issue = _mapper.Map<Issue>(request);
            await _repository.UpdateAsync(issue);

            var @event = _mapper.Map<IssueUpdated>(issue);
            await _eventBus.Publish(@event);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteIssue request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            var @event = _mapper.Map<IssueDeleted>(request);
            await _eventBus.Publish(@event);

            return Unit.Value;
        }
    }
}
