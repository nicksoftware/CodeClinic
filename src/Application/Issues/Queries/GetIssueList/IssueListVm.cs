using System.Collections.Generic;
using CodeClinic.Application.Issues.Queries;

namespace CodeClinic.Application.Issues.Queries.GetIssueList
{
    public class IssueListVm 
    {
        public IList<ProgressStatusDto> ProgressStatuses{ get; set; }

        public IList<IssueDto> Issues { get; set; }
    }
}
