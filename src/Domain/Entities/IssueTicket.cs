using CodeClinic.Domain.Common;
using CodeClinic.Domain.Enums;
using System.Collections.Generic;

namespace CodeClinic.Domain.Entities
{
    public class IssueTicket : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public ProgressStatus Status { get; set; }
        public Category Category { get; private set; }

        public IList<Comment> Comments { get; private  set; } = new List<Comment>();
    }
}