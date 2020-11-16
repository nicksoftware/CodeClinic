using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;

namespace CodeClinic.Application.Issues.Queries.GetIssueList
{
    public class IssueTicketDto :IMapFrom<IssueTicket>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Stars { get; set; }

        public int Status { get; set; }
        public string Body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IssueTicket, IssueTicketDto>()
                .ForMember(s => s.Status, op => op.MapFrom(s => (int)s.Status));
        }
    }
}
