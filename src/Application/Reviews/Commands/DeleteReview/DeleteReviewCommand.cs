using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public int IssueTicketId { get; set; }

        public int Id { get; set; }
    }

    public class DeleteReviewCommandHandler : ReviewCommandBaseHandler, IRequestHandler<DeleteReviewCommand>
    {
        public DeleteReviewCommandHandler(IApplicationDbContext context) : base(context) { }


        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reviews.FindAsync(request.Id);

            if (entity == null) throw new NotFoundException(nameof(Review), request.Id);

            _context.Reviews.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
