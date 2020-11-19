using CodeClinic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CodeClinic.Domain.Entities
{
   public class Category : AuditableEntity
    {
        public Category()
        {
            IssueTickets = new List<IssueTicket>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<IssueTicket> IssueTickets { get; private set; } 
    }
}
