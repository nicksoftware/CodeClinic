using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryCommandValidator(IApplicationDbContext context)
        {
            RuleFor(n => n.Name)
                .MaximumLength(50)
                .WithMessage("Name should not be greater than 50 characters")
                .NotNull().NotEmpty().WithMessage("Name is required")
                .MustAsync(BeUnique).WithMessage("Category must be Unique");

            RuleFor(d => d.Description)
                .MaximumLength(500).WithMessage("Description should be short") ;
            _context = context;
        }

        public async Task<bool> BeUnique(CreateCategoryCommand request,string name,CancellationToken cancellationToken)
        {
            return await _context
                .Categories
                .Where(n => n.Id != request.Id)
                .AllAsync(n => n.Name != request.Name);
        }
    }
}
