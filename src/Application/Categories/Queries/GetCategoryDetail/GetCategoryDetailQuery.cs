using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Categories.Queries.GetCategory
{
    public class GetCategoryDetailQuery:IRequest<CategoryDetailVm>
    {
        public int Id { get;  set; }
    }

    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryDetailVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _context.Categories
                .ProjectTo<CategoryDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.CategoryId == request.Id, cancellationToken);

            if (viewModel == null) throw new NotFoundException(nameof(Category), request.Id);

            var issueTicketList = await _context.IssueTickets.ProjectTo<IssueTicketDto>(_mapper.ConfigurationProvider)
                .Where(c => c.CategoryId == request.Id).ToListAsync();


            viewModel.IssuesTickets = issueTicketList;
            return viewModel;
        }
    }

}
