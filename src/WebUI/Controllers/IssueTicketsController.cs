using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Application.Issues.Commands.DeleteIssue;
using CodeClinic.Application.Issues.Commands.UpdateIssue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodeClinic.Application.IssueTickets.Commands.UpdateIssueTicket;
using CodeClinic.Application.IssueItems.Queries.GetIssueDetail;
using CodeClinic.Application.IssueTickets.Queries.GetIssueDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeClinic.WebUI.Controllers
{
    
    public class IssueTicketsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IssueTicketListVm>> GetAll()
        {
            return await Mediator.Send(new GetIssueTicketListQuery());
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<IssueTicketDetailVm>> GetIssueTicketById(int id)
        {
          
            return await Mediator.Send(new GetIssueTicketDetailQuery { Id = id });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIssueTicketCommand command)
        {
            return await Mediator.Send(command);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateIssueTicketCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize]
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateDetails(int id, UpdateIssueTicketDetailsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteIssueTicketCommand { Id = id });

            return NoContent();
        }
    }
}
