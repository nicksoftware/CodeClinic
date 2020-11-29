using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Likes.Commands
{
    public class CreateLikeCommand :IRequest<int>
    {

        public int CommentId { get; set; }

        public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateLikeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            async Task<int> IRequestHandler<CreateLikeCommand, int>.Handle(CreateLikeCommand request, CancellationToken cancellationToken)
            {

                if (request.CommentId == 0)
                    throw new Exception("Comment Id Cannot be empty");

                var like = new Like { CommentId = request.CommentId , IsLiked = true };

                _context.Likes.Add(like);

                await _context.SaveChangesAsync(cancellationToken);

                return like.Id;
            }
        }
    }
}
