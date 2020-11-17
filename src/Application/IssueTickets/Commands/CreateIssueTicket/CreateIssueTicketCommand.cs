using CodeClinic.Domain.Entities;
using MediatR;

namespace Application.Issues.Commands.CreateIssue
{
    public class CreateIssueTicketCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int  CategoryId { get; set; }
        public string Body { get; set; }
  
    }


}