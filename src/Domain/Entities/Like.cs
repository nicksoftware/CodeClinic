
using CodeClinic.Domain.Common;

namespace CodeClinic.Domain.Entities
{
    public class Like : BaseEntity
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public bool IsLiked { get; set; }
    }
}