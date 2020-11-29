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

namespace CodeClinic.Application.Comments.Query.GetCommentList
{
    public class GetCommentListQuery : IRequest<CommentListVm>
    {
        public GetCommentListQuery(int issueTicketId)
        {
            IssueTicketId = issueTicketId;
        }
        public int IssueTicketId { get; private set; }
    }

    public class GetCommentsListQueryHandler : IRequestHandler<GetCommentListQuery, CommentListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentListVm> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments
                .Where(it => it.IssueTicketId == request.IssueTicketId)
                .Include(u=> u.Likes)
        .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

            if (comments == null)
                throw new NotFoundException(nameof(Comment), request.IssueTicketId);
            
            CommentListVm vm = new CommentListVm { Items = comments };

            if (comments != null) return vm;

            return new CommentListVm();
        }
    }
}
