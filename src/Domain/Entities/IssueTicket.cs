using CodeClinic.Domain.Common;
using CodeClinic.Domain.Enums;
using System.Collections.Generic;

namespace CodeClinic.Domain.Entities
{
    public class IssueTicket : AuditableEntity
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }
        public int Stars { get; set; }
        public string Body { get; set; }

        public ProgressStatus Status { get; set; }
        public Category Category { get; set; }

        public IList<Review> Reviews { get;  set; } = new List<Review>();
    }
}