using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Comments.Commands.UpdateComment
{
    class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(i => i.CommentId).NotEmpty()
                .NotNull();

            RuleFor(t => t.IssueTicketId)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("400").WithMessage("Issue Ticket Id is Required");

            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("The title is required");
        }
    }
}
