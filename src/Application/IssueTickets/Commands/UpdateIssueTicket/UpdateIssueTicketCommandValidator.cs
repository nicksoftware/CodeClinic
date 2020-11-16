using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CodeClinic.Application.Issues.Commands.CreateIssue
{
    class UpdateIssueTicketCommandValidator : AbstractValidator<CreateIssueTicketCommand>
    {
 
        public UpdateIssueTicketCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(v => v.Title)
         .NotEmpty().WithMessage("Title is required.")
         .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
        }
    }
}
