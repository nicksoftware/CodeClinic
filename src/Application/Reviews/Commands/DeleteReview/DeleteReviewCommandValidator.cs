using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Reviews.Commands.DeleteReview
{
    class DeleteReviewCommandValidator :AbstractValidator<DeleteReviewCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteReviewCommandValidator(IApplicationDbContext context)
        {
            _context = context;
        }
        public DeleteReviewCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().NotNull().WithMessage("Review Id is Required!");

            RuleFor(i => i.IssueTicketId).NotEmpty()
                .MustAsync(MustBeInTheIssueTicket)
                .WithMessage("Ticket does not contain review with given Id!");
        }

        public async Task<bool> MustBeInTheIssueTicket(DeleteReviewCommand request, int issueTickeId, CancellationToken cancellationToken)
        {
            var ticket = await _context.IssueTickets.FirstOrDefaultAsync(i => i.Id == request.IssueTicketId && i.Reviews.FirstOrDefault(r => r.IssueTicketId == issueTickeId ) != null);
            return ticket != null;
        }
    }
}
