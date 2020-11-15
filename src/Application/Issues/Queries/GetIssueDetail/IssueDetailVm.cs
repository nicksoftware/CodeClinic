using AutoMapper;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.IssueItems.Queries.GetIssueDetail
{
   public class IssueDetailVm
    {
        public int IssueId { get; set; }
        public int WardId { get; set; }

        public string Title { get; set; }
        public int Stars { get; set; }

        public int Status { get; set; }
        public string Body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Issue, IssueDetailVm>()
                .ForMember(s => s.Status, op => op.MapFrom(s => (int)s.Status));
        }
    }
}
