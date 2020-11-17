using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.IssueTickets.Commands.UpdateIssueTicket
{
    public partial class UpdateIssueTicketCommandHandler : IRequestHandler<UpdateIssueTicketCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateIssueTicketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateIssueTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.IssueTickets.FindAsync(request.Id);

            if(entity == null) throw new  NotFoundException(nameof(IssueTicket), request.Id);

            entity.Status = request.Status;
            entity.Stars = request.Stars;
            _context.IssueTickets.Update(entity);

           await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
