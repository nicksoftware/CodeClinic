using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Likes.Commands.UpdateLike
{
    public class UpdateLikeCommand : IRequest
    {
        public int LikeId { get; set; }

        public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateLikeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
            {

                var like = await _context.Likes.FindAsync(request.LikeId, cancellationToken) ;

                if (like == null)
                    throw new NotFoundException(nameof(Like), request.LikeId);

                like.IsLiked = !like.IsLiked;

                return Unit.Value;
            }
        }
    }
}
