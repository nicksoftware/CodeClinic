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

    public class GetDiagnosisListQueryHandler : IRequestHandler<GetCommentListQuery, CommentListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDiagnosisListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommentListVm> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var diagnoses = await _context.Comments.Where(it => it.IssueTicketId == request.IssueTicketId)
        .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);


            if (diagnoses == null)
                throw new NotFoundException(nameof(Comment), request.IssueTicketId);
            
            CommentListVm vm = new CommentListVm
            {
                Items = diagnoses
            };

            if (diagnoses != null)
            {
                return vm;
            }

            return new CommentListVm();
        }
    }
}
