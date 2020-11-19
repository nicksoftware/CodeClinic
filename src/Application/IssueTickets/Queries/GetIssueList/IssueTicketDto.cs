using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;
using System;

namespace CodeClinic.Application.Issues.Queries.GetIssueList
{
    public class IssueTicketDto :IMapFrom<IssueTicket>
    {
        public int IssueTicketId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }
        public int Status { get; set; }
        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<IssueTicket, IssueTicketDto>()
                .ForMember(i=> i.IssueTicketId, opt=> opt.MapFrom(i=> i.Id))
                .ForMember(s => s.Status, op => op.MapFrom(s => (int)s.Status))
                .ForMember(c => c.CategoryName, op => op.MapFrom(c => c.Category.Name))
                .ForMember(cb => cb.CreatedBy, cf => cf.MapFrom(c => c.CreatedBy ?? string.Empty))
                .ForMember(lm => lm.LastModifiedBy, opt => opt.MapFrom(c => c.LastModified != null ? c.LastModifiedBy : string.Empty));
        }
    }
}
