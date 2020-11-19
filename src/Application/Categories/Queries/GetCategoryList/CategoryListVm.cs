using CodeClinic.Domain.Entities;
using System.Collections.Generic;

namespace CodeClinic.Application.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public List<CategoryDto> Categories { get; internal set; } 
    }
}