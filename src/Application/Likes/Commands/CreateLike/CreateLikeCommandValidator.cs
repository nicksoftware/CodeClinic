using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Application.Common.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Likes.Commands
{
    class CreateLikeCommandValidator : AbstractValidator<CreateLikeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateLikeCommandValidator(IApplicationDbContext context,ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public CreateLikeCommandValidator()
        {

            RuleFor(c => c.CommentId)
                .NotEmpty()
                .WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("Comment Id cannot be empty")
                .MustAsync(NotExist)
                .WithErrorCode(ErrorCode.BadRequest)
                .WithMessage("Comment already liked by user");
        }

        private async Task<bool> NotExist(int commentId, CancellationToken cancellationToken)
        {

            var userId = _currentUserService.UserId;

            var like =  await  _context.Likes
                .SingleOrDefaultAsync(x => x.CreatedBy == userId && x.CommentId == commentId);

            return like == null;
        }
    }
}
