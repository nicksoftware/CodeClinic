using CodeClinic.Application.Issues.Queries.GetIssueList;
using CodeClinic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Application.IntegrationTests.Issues.Queries
{
    using static Testing;

    public class GetIssueListQueryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnListOfIssues()
        {
            var query = new GetIssueListQuery();

            var result = await SendAsync(query);

            result.Issues.Should().NotBeEmpty();
        }
    }
}
