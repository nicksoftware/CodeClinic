using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Common.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.TodoItems.Commands.UpdateTodoItem
{
    public class CreateIssueTicketCommandValidator : AbstractValidator<CreateIssueTicketCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateIssueTicketCommandValidator(IApplicationDbContext context)
        {
            
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty().WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("Title cannot be longer than 200 characters");

            RuleFor(c => c.CategoryId)
                .NotNull()
                .GreaterThan(0) 
                .MustAsync(HaveAnExistingCategory).WithErrorCode(ErrorCode.NotFound)
                .WithMessage("Choose a Category that exists in the system");
            _context = context;
        }

        public async Task<bool> HaveAnExistingCategory(CreateIssueTicketCommand request, int CategoryId, CancellationToken cancellationToken)
        {
            return await _context.Categories.AnyAsync(c => c.Id == CategoryId);
        }
    }
}
