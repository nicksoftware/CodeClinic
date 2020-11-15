using CodeClinic.Domain.Common;
using CodeClinic.Domain.Enums;

namespace CodeClinic.Domain.Entities
{
    public class Issue : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }

        public ProgressStatus Status { get; set; }
        public string Body { get; set; }
    }
}