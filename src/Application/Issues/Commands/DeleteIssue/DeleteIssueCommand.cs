using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;


namespace CodeClinic.Application.Issues.Commands.DeleteIssue
{
  public  class DeleteIssueCommand :IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteIssueCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Issues.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            _context.Issues.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
