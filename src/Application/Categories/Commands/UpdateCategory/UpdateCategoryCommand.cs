using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
