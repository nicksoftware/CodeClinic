using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<int>
    {
        public int IssueTicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }


    public class CreateReviewCommandHandler : ReviewCommandBaseHandler, IRequestHandler<CreateReviewCommand, int>
    {
        public CreateReviewCommandHandler(IApplicationDbContext context) : base(context) { }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var issueTicket = await _context.IssueTickets.FindAsync(request.IssueTicketId);

            if (issueTicket == null)
                throw 
                    new PostException(nameof(Review),
                    new NotFoundException($"The Depend Entity '{nameof(IssueTicket)}'" +
                    $" with Id {request.IssueTicketId} was not found"));
               
            var entity = new Review
            {
                IssueTicketId = request.IssueTicketId,  
                Title = request.Title,
                Description = request.Description
            };

            _context.Reviews.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
