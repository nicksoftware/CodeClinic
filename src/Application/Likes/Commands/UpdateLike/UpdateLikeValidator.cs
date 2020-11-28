using FluentValidation;
using CodeClinic.Application.Common.Models;

namespace CodeClinic.Application.Likes.Commands.UpdateLike
{
    public class UpdateLikeValidator : AbstractValidator<UpdateLikeCommand>
    {

        public UpdateLikeValidator()
        {
            RuleFor(i => i.LikeId)
                .NotEqual(0)
                .WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("Like Id cannot be equal to 0");
        }
    }
}
