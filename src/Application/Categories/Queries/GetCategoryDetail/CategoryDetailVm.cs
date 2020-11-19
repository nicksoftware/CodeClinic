using AutoMapper;
using CodeClinic.Application.Categories.Queries.GetCategoryList;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CodeClinic.Application.Categories.Queries.GetCategory
{
    public class CategoryDetailVm : IMapFrom<Category>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
        public IList<IssueTicketDto> IssuesTickets { get; set; } = new List<IssueTicketDto>();



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDetailVm>()
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
                .ForMember(c=> c.CategoryName , cd=> cd.MapFrom(c=> c.Name))
                .ForMember(c=> c.CategoryDescription,op=> op.MapFrom(d=> d.Description));
        }
    }
}