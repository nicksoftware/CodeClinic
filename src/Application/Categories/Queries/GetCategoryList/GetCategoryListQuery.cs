using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Categories.Queries.GetCategoryList
{
   public class GetCategoryListQuery : IRequest<CategoryListVm>
    {
    }

    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            var viewModel = new CategoryListVm
            {
                Categories = categories
            };

            return viewModel;
        }
    }
}
