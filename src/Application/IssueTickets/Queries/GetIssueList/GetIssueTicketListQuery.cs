using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Interfaces;
using MediatR;
using CodeClinic.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Issues.Queries.GetIssueList
{
   public class GetIssueTicketListQuery : IRequest<IssueTicketListVm>
    {
    }

    public class GetIssueTicketQueryHandler : IRequestHandler<GetIssueTicketListQuery, IssueTicketListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIssueTicketQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IssueTicketListVm> Handle(GetIssueTicketListQuery request,
            CancellationToken cancellationToken)
        {
            var issues =  await _context.IssueTickets
                .ProjectTo<IssueTicketDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.Title).ToListAsync(cancellationToken);

            var progressStatuses = Enum.GetValues(typeof(ProgressStatus))
                    .Cast<ProgressStatus>()
                    .Select(p => new ProgressStatusDto { Value = (int)p, Name = p.ToString() })
                    .ToList();

            var viewModel = new IssueTicketListVm
            {
                Issues = issues,
                ProgressStatuses = progressStatuses
            };

            return viewModel;

        }
    }
}
