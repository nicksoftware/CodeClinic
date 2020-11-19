using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Commands.DeleteComment
{
    class DeleteCommentCommandValidator :AbstractValidator<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentCommandValidator(IApplicationDbContext context)
        {
            _context = context;
        }
        public DeleteCommentCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().NotNull().WithMessage("Comment Id is Required!");

            RuleFor(i => i.IssueTicketId).NotEmpty()
                .MustAsync(MustBeInTheIssueTicket)
                .WithMessage("Ticket does not contain Comment with given Id!");
        }

        public async Task<bool> MustBeInTheIssueTicket(DeleteCommentCommand request, int issueTickeId, CancellationToken cancellationToken)
        {
            var ticket = await _context.IssueTickets.FirstOrDefaultAsync(i => i.Id == request.IssueTicketId && i.Comments.FirstOrDefault(r => r.IssueTicketId == issueTickeId ) != null);
            return ticket != null;
        }
    }
}
