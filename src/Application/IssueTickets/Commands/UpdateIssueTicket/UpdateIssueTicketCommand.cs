using CodeClinic.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.IssueTickets.Commands.UpdateIssueTicket
{
    public  class UpdateIssueTicketCommand : IRequest
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public ProgressStatus Status { get; set; }
    }
}
