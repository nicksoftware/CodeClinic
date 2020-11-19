using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace CodeClinic.Application.Categories.Commands.DeleteCategory
{
    public  class DeleteCategoryCommand :IRequest
    {
        public int Id { get; set; }
    }
}
