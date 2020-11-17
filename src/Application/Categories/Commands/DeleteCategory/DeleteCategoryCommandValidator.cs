using FluentValidation;

namespace CodeClinic.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            

            RuleFor(c => c.Id).NotNull()
                .NotEmpty().WithMessage("Id Cannot be null");
        }

    }
}
