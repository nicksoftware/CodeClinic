using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Domain.Entities;

namespace CodeClinic.Application.Comments.Query.GetCommentList
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int CommentId { get; set; }
        public int IssueTicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>()
                .ForMember(i => i.CommentId, opt => opt.MapFrom(d => d.Id));
        }

    }
}
