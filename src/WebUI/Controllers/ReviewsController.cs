using System.Security.Cryptography;
using CodeClinic.Application.Comments.Query.GetCommentList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodeClinic.Application.Comments.Commands.CreateComment;
using CodeClinic.Application.Comments.Commands.UpdateComment;
using CodeClinic.Application.Comments.Commands.DeleteComment;
using CodeClinic.Application.Comments.Query.GetCommentDetails;

namespace CodeClinic.WebUI.Controllers
{
    [Route("api/issueTickets/{issueTicketId}/[controller]")]
    public class CommentsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<CommentListVm>> GetAll(int issueTicketId)
        {
            return await Mediator.Send(new GetCommentListQuery(issueTicketId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetCommentById(int issueTicketId,int id)
        {
            return await Mediator.Send(new GetCommentDetailsQuery { IssueTicketId = issueTicketId,CommentId = id });
        }

        [HttpPost]
        public async Task<ActionResult> Create(int issueTicketId, CreateCommentCommand command)
        {
            if (issueTicketId != command.IssueTicketId)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCommentCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int issueTicketId,int id)
        {
            await Mediator.Send(new DeleteCommentCommand {IssueTicketId = issueTicketId, Id = id});
            return NoContent();
        }
    }
}
