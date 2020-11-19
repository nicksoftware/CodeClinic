using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Comments.Query.GetCommentList;
using CodeClinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Query.GetCommentDetails
{
    public class GetCommentDetailsQuery : IRequest<CommentDto>
    {
        public int IssueTicketId { get; set; }
        public int CommentId { get; set; }
    }

    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {
            var diagnosis = await _context.Comments
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(i => i.CommentId == request.CommentId, cancellationToken);

            if (diagnosis == null) throw new NotFoundException(nameof(Comment), request.CommentId);
            if (diagnosis.IssueTicketId != request.IssueTicketId)
                throw new NotFoundException($"Comment of id {request.CommentId} in Ticket {request.IssueTicketId} was not found");

            return diagnosis;
        }
    }
}
