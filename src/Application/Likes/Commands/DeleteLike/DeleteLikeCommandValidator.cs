using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using CodeClinic.Application.Common.Models;

namespace CodeClinic.Application.Likes.Commands.DeleteLike
{
    class DeleteLikeCommandValidator : AbstractValidator<DeleteLikeCommand>
    {

        public DeleteLikeCommandValidator()
        {
            RuleFor(c => c.LikeId)
                .NotEqual(0)
                .WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("Invalid Id");



        }
    }
}
