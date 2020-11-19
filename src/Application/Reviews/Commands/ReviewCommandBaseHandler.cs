using CodeClinic.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Reviews.Commands
{
    public class ReviewCommandBaseHandler
    {
        protected readonly IApplicationDbContext _context;

        public ReviewCommandBaseHandler(IApplicationDbContext context)
        {
            _context = context;
        }


    }

}
