using System.Collections.Generic;
using CodeClinic.Application.Issues.Queries;

namespace CodeClinic.Application.Issues.Queries.GetIssueList
{
    public class IssueTicketListVm 
    {
        public IList<ProgressStatusDto> ProgressStatuses{ get; set; }

        public IList<IssueTicketDto> Issues { get; set; }
    }
}
