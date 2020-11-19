using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Reviews.Commands.UpdateReview
{
    class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidator()
        {
            RuleFor(i => i.ReviewId).NotEmpty()
                .NotNull();

            RuleFor(t => t.IssueTicketId)
                .NotEmpty().NotNull()
                .WithErrorCode("400")
                .WithMessage("Issue Ticket Id is Required");

            RuleFor(t => t.Title)
                .NotEmpty()
                .WithMessage("The title is required");
        }
    }
}
