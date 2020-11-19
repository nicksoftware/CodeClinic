using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public int IssueTicketId { get; set; }

        public int Id { get; set; }
    }

    public class DeleteCommentCommandHandler : CommentCommandBaseHandler, IRequestHandler<DeleteCommentCommand>
    {
        public DeleteCommentCommandHandler(IApplicationDbContext context) : base(context) { }


        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comments.FindAsync(request.Id);

            if (entity == null) throw new NotFoundException(nameof(Comment), request.Id);

            _context.Comments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
