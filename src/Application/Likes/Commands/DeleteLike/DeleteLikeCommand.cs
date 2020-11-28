using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Domain.Entities;

namespace CodeClinic.Application.Likes.Commands.DeleteLike
{
   public  class DeleteLikeCommand :IRequest
    {
        public int LikeId { get; set; }

        public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteLikeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
            {

                var like = await _context.Likes.FindAsync(request.LikeId,cancellationToken);

                if (like == null) throw new NotFoundException(nameof(Like), request.LikeId);

                _context.Likes.Remove(like);

                return Unit.Value;
            }
        }
    }

}
