using Application.Issues.Commands.CreateIssue;
using CodeClinic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace CodeClinic.Application.IntegrationTests.Issues.Commands
{
    using static Testing;

  public  class CreateIssueTests :TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateIssueTicketCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateIssue()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateIssueTicketCommand
            {
                Title = "Tasks"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<IssueTicket>(itemId);

            item.Should().NotBeNull();
 
            item.Title.Should().Be(command.Title);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
