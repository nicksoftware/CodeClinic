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

namespace CodeClinic.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest
    {
        public int IssueTicketId { get; set; }
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class UpdateReviewCommandHandler : ReviewCommandBaseHandler, IRequestHandler<UpdateReviewCommand>
    {
        public UpdateReviewCommandHandler(IApplicationDbContext context) : base(context) { }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {

            Review entity = await _context.Reviews.FindAsync(request.ReviewId);

            if (entity == null) throw new NotFoundException(nameof(Review), request.ReviewId);

            entity.Title = request.Title;
            entity.Description = request.Description;

            _context.Reviews.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
