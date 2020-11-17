using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Issues.Commands.UpdateIssue
{
    public class UpdateIssueTicketDetailsCommand : IRequest
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string  Body { get; set; }

        public class UpdateIssueDetailsCommandHandler : IRequestHandler<UpdateIssueTicketDetailsCommand>
        {
            private readonly IApplicationDbContext _ctx;

            public UpdateIssueDetailsCommandHandler(IApplicationDbContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Unit> Handle(UpdateIssueTicketDetailsCommand request, CancellationToken cancellationToken)
            {
                var entity = await _ctx.IssueTickets.FindAsync(request.Id);

                if (entity == null) throw new NotFoundException(nameof(IssueTicket), request.Id);

                entity.Title = request.Title;
                entity.Body = request.Body;
                entity.CategoryId = request.CategoryId;

                _ctx.IssueTickets.Update(entity);

                await _ctx.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }


    
}
