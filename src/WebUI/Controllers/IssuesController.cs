using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Application.Issues.Commands.DeleteIssue;
using CodeClinic.Application.Issues.Commands.UpdateIssue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeClinic.WebUI.Controllers
{
    [Authorize]
    public class IssuesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IssueListVm>> GetAll()
        {
            return await Mediator.Send(new GetIssueListQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIssueCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateIssueCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteIssueCommand { Id = id });

            return NoContent();
        }
    }
}
