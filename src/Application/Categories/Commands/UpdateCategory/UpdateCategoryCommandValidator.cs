using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Categories.Commands.UpdateCategory
{

    public partial class UpdateCategoryCommandHandler
    {
        public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateCategoryCommandValidator(IApplicationDbContext context)
            {
                RuleFor(n => n.Name)
                .MaximumLength(50)
                .WithMessage("Name should not be greater than 50 characters")
                .NotNull().NotEmpty().WithMessage("Name is required")
                .MustAsync(BeUniqueName).WithMessage("Category must be Unique");

                _context = context;
            }
            public async Task<bool> BeUniqueName(UpdateCategoryCommand model, string name, CancellationToken cancellationToken)
            {
                return await _context.Categories
                    .Where(l => l.Id != model.Id)
                    .AllAsync(l => l.Name != name);
            }
        }
    }
}
