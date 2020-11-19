using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public int IssueTicketId { get; set; }
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class UpdateCommentCommandHandler : CommentCommandBaseHandler, IRequestHandler<UpdateCommentCommand>
    {
        public UpdateCommentCommandHandler(IApplicationDbContext context) : base(context) { }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {

            Comment entity = await _context.Comments.FindAsync(request.CommentId);

            if (entity == null) throw new NotFoundException(nameof(Comment), request.CommentId);

            entity.Title = request.Title;
            entity.Description = request.Description;

            _context.Comments.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
