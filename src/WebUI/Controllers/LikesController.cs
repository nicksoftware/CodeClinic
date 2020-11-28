using CodeClinic.Application.Likes.Commands;
using CodeClinic.Application.Likes.Commands.DeleteLike;
using CodeClinic.Application.Likes.Commands.UpdateLike;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeClinic.WebUI.Controllers
{

    [Authorize]
    [Route("api/likes/{CommentId}/[controller]")]
    public class LikesController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult> CreateLike( int commentId,CreateLikeCommand command )
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateLike(int id,UpdateLikeCommand command)
        {
            if (id != command.LikeId)
                return BadRequest();

             await Mediator.Send(command);
             return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLike(DeleteLikeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
