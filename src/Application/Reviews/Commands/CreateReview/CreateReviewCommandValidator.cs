using CodeClinic.Application.Common.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Reviews.Commands.CreateReview
{
    class CreateReviewCommandValidator: AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(t => t.IssueTicketId)
                .NotEmpty().NotNull()
                .WithErrorCode( ErrorCode.BadRequest)
                .WithMessage("Issue Ticket Id is Required");
            
            RuleFor(t => t.Title)
                .NotEmpty().WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("The title is required");
        }
    }
}
