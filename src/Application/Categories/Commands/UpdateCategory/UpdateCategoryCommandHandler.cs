using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Categories.Commands.UpdateCategory
{
    public partial class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryUpdate = await _context.Categories.FindAsync(request.Id);
            if (categoryUpdate == null)
                throw new NotFoundException(nameof(Category), request.Id);


            categoryUpdate.Name = request.Name;
            categoryUpdate.Description = request.Description;

            _context.Categories.Update(categoryUpdate);

           await _context.SaveChangesAsync(cancellationToken);
           
            return Unit.Value;
        }
    }
}
