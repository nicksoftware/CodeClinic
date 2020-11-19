using CodeClinic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Domain.Entities
{
   public class Review :AuditableEntity
    {

        public int IssueTicketId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueTicket IssueTicket { get; set; }
    }
}
