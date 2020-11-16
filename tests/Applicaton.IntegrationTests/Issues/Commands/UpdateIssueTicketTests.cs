using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Issues.Commands.UpdateIssue;
using CodeClinic.Application.IssueTickets.Commands.UpdateIssueTicket;
using CodeClinic.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeClinic.Application.IntegrationTests.Issues.Commands
{
    using static Testing;
    class UpdateIssueTicketTests :TestBase
    {

        [Test]
        public void UpdateIssueCommandCalled_ShouldRequireValidId()
        {
            var command = new CreateIssueTicketCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions
                .Invoking(() =>
                SendAsync(command))
                .Should()
                .Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();


            var itemId = await SendAsync(new CreateIssueTicketCommand
            {
                Title = "Updated Issue",
                Body = "This is the  updated Issue.",
            });

            var command = new UpdateIssueTicketCommand
            {
                Id = itemId,
                Status = Domain.Enums.ProgressStatus.Answered,
            };

            await SendAsync(command);

            var item = await FindAsync<IssueTicket>(itemId);

            item.Stars.Should().NotBe(command.Stars);
            item.Status.Should().NotBe(command.Status);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }

    }
}
