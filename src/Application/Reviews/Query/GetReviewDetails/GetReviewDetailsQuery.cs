using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Reviews.Query.GetReviewList;
using CodeClinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Reviews.Query.GetReviewDetails
{
    public class GetReviewDetailsQuery : IRequest<ReviewDto>
    {
        public int IssueTicketId { get; set; }
        public int ReviewId { get; set; }
    }

    public class GetReviewDetailsQueryHandler : IRequestHandler<GetReviewDetailsQuery, ReviewDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReviewDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReviewDto> Handle(GetReviewDetailsQuery request, CancellationToken cancellationToken)
        {
            var diagnosis = await _context.Reviews
                .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(i => i.ReviewId == request.ReviewId, cancellationToken);

            if (diagnosis == null) throw new NotFoundException(nameof(Review), request.ReviewId);
            if (diagnosis.IssueTicketId != request.IssueTicketId)
                throw new NotFoundException($"Review of id {request.ReviewId} in Ticket {request.IssueTicketId} was not found");

            return diagnosis;
        }
    }
}
