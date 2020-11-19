using System.Security.Cryptography;
using CodeClinic.Application.Reviews.Query.GetReviewList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodeClinic.Application.Reviews.Commands.CreateReview;
using CodeClinic.Application.Reviews.Commands.UpdateReview;
using CodeClinic.Application.Reviews.Commands.DeleteReview;
using CodeClinic.Application.Reviews.Query.GetReviewDetails;

namespace CodeClinic.WebUI.Controllers
{
    [Route("api/issueTickets/{issueTicketId}/[controller]")]
    public class ReviewsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<ReviewListVm>> GetAll(int issueTicketId)
        {
            return await Mediator.Send(new GetReviewListQuery(issueTicketId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int issueTicketId,int id)
        {
            return await Mediator.Send(new GetReviewDetailsQuery { IssueTicketId = issueTicketId,ReviewId = id });
        }

        [HttpPost]
        public async Task<ActionResult> Create(int issueTicketId, CreateReviewCommand command)
        {
            if (issueTicketId != command.IssueTicketId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateReviewCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int issueTicketId,int id)
        {
            await Mediator.Send(new DeleteReviewCommand {IssueTicketId = issueTicketId, Id = id});
            return NoContent();
        }
    }
}
