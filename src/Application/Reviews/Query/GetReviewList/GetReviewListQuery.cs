using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Reviews.Query.GetReviewList
{
    public class GetReviewListQuery : IRequest<ReviewListVm>
    {
        public GetReviewListQuery(int issueTicketId)
        {
            IssueTicketId = issueTicketId;
        }
        public int IssueTicketId { get; private set; }
    }

    public class GetDiagnosisListQueryHandler : IRequestHandler<GetReviewListQuery, ReviewListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDiagnosisListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReviewListVm> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            var diagnoses = await _context.Reviews.Where(it => it.IssueTicketId == request.IssueTicketId)
        .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);


            if (diagnoses == null)
                throw new NotFoundException(nameof(Review), request.IssueTicketId);
            
            ReviewListVm vm = new ReviewListVm
            {
                Items = diagnoses
            };

            if (diagnoses != null)
            {
                return vm;
            }

            return new ReviewListVm();
        }
    }
}
