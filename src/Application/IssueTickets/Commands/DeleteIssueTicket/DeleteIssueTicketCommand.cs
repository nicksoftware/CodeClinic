using System;
using System.Text;
using MediatR;


namespace CodeClinic.Application.Issues.Commands.DeleteIssue
{
    public  class DeleteIssueTicketCommand :IRequest
    {
        public int Id { get; set; }
    }


}
