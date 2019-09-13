using DRP.Core.Contracts.Issues.Commands;
using DRP.Core.Contracts.Issues.Queries;
using DRP.Core.Contracts.Issues.Views;
using DRP.Core.CQRS.Abstractions.Commands;
using DRP.Core.CQRS.Abstractions.Queries;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRP.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public IssuesController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus ?? throw new ArgumentException(nameof(commandBus));
            _queryBus = queryBus ?? throw new ArgumentException(nameof(queryBus));
        }

        // GET api/values
        [HttpGet]
        public Task<IReadOnlyList<IssueView>> Get()
        {
            return _queryBus.Send<GetIssues, IReadOnlyList<IssueView>>(new GetIssues());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<IssueView> Get([FromRoute] Guid id)
        {
            return _queryBus.Send<GetIssue, IssueView>(new GetIssue(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIssue command)
        {
            await _commandBus.Send(command);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateIssue command)
        {
            await _commandBus.Send(command);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _commandBus.Send(new DeleteIssue(id));

            return Ok();
        }
    }
}
