using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Domain.Entities;
using System.Collections.Generic;

namespace CodeClinic.Application.Categories.Queries.GetCategoryList
{
    public class CategoryDto : IMapFrom<Category>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>()
                .ForMember(i => i.CategoryId, op => op.MapFrom(s => s.Id));
        }
    }
}