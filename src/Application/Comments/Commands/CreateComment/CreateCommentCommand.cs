using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public int IssueTicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }


    public class CreateCommentCommandHandler : CommentCommandBaseHandler, IRequestHandler<CreateCommentCommand, int>
    {
        public CreateCommentCommandHandler(IApplicationDbContext context) : base(context) { }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var issueTicket = await _context.IssueTickets.FindAsync(request.IssueTicketId);

            if (issueTicket == null)
                throw 
                    new PostException(nameof(Comment),
                    new NotFoundException($"The Depend Entity '{nameof(IssueTicket)}'" +
                    $" with Id {request.IssueTicketId} was not found"));
               
            var entity = new Comment
            {
                IssueTicketId = request.IssueTicketId,  
                Title = request.Title,
                Description = request.Description
            };

            _context.Comments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
