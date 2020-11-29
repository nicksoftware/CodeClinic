using CodeClinic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeClinic.Domain.Common
{
   public class BaseEntity : AuditableEntity
    {
        public int Id { get; set; }
    }
}
