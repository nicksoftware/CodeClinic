using FluentValidation;

namespace CodeClinic.Application.IssueTickets.Commands.UpdateIssueTicket
{

    public partial class UpdateIssueTicketCommandHandler
    {
        public class UpdateIssueTicketCommandValidator : AbstractValidator<UpdateIssueTicketCommand>
        {
            public UpdateIssueTicketCommandValidator()
            {
                RuleFor(s => s.Stars)
                    .GreaterThanOrEqualTo(0).NotNull().NotEmpty()
                    .WithMessage("Star Rating Cannot be less than Zero");

                RuleFor(a => a.Status)
                    .NotNull().NotEmpty()
                    .WithMessage("Status cannot be null or empty");
            }
        }
    }
}
