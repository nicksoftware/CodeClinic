using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Categories.Commands.CreateCategory
{
    public  class CreateCategoryCommand : IRequest<int>
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
