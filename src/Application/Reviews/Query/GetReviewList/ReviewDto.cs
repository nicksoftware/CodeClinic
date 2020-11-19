using AutoMapper;
using CodeClinic.Application.Common.Mappings;
using CodeClinic.Domain.Entities;

namespace CodeClinic.Application.Reviews.Query.GetReviewList
{
    public class ReviewDto : IMapFrom<Review>
    {
        public int ReviewId { get; set; }
        public int IssueTicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Review, ReviewDto>()
                .ForMember(i => i.ReviewId, opt => opt.MapFrom(d => d.Id));
        }

    }
}
