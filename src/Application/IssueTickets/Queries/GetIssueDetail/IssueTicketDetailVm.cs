using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Application.Reviews.Query.GetReviewList;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.IssueTickets.Queries.GetIssueDetail
{
  public class IssueTicketDetailVm:IMapFrom<IssueTicket>
  {
        public int CategoryId { get; set; }
        public int IssueTicketId { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }
        public string Body { get; set; }

        public ProgressStatus Status { get; set; }
        public string CategoryName { get; set; }

        public IList<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();


        public void Mapping(Profile profile)
        {
            profile.CreateMap<IssueTicket, IssueTicketDetailVm>()
                .ForMember(c => c.CategoryName, o => o.MapFrom(c => c.Category.Name))
                .ForMember(i => i.IssueTicketId, o => o.MapFrom(c => c.Id));
        }
  }
}
