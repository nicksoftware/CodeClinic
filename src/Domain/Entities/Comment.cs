using CodeClinic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Domain.Entities
{
   public class Comment : BaseEntity
    {

        public int IssueTicketId { get; set; }

        public int DisLikes { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueTicket IssueTicket { get;private set; }

        public List<Like> Likes { get; private  set; } = new List<Like>();

    }
}
