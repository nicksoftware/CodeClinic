using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Issues.Commands.CreateIssue
{
    public class CreateIssueTicketCommand : IRequest<int>
    {
        public string Title { get; set; }
        
        public string Body { get; set; }
  
    }
    public class CreateIssueTicketCommandHandler : IRequestHandler<CreateIssueTicketCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateIssueTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateIssueTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = new IssueTicket
            {
                Title = request.Title,
                Body = request.Body,
            };

            _context.Issues.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }


}