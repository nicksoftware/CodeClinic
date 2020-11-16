using CodeClinic.Domain.Common;
using CodeClinic.Domain.Enums;

namespace CodeClinic.Domain.Entities
{
    public class IssueTicket : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }
        public string Body { get; set; }

        public ProgressStatus Status { get; set; }
    }
}