using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Comments.Commands
{
    public class CommentCommandBaseHandler
    {
        protected readonly IApplicationDbContext _context;

        public CommentCommandBaseHandler(IApplicationDbContext context)
        {
            _context = context;
        }


    }

}
