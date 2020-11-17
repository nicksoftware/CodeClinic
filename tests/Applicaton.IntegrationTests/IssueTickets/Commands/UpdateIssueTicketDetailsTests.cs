using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Issues.Commands.UpdateIssue;
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
    class UpdateIssueTicketDetailsTests :TestBase
    {

        [Test]
        public void UpdateIssueCommandCalled_ShouldRequireValidId()
        {
            var command = new UpdateIssueTicketDetailsCommand
            {
                Id = 99,
                Title = "This is my Issue",
                 Body = "I cant do ssomething"
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
                Title = "New Issue"
            });

            var command = new UpdateIssueTicketDetailsCommand
            {
                Id = itemId,
                Title = "Updated Issue",
                Body = "This is the  updated Issue."
            };

            await SendAsync(command);

            var item = await FindAsync<IssueTicket>(itemId);

            item.Title.Should().NotBe(command.Title);
            item.Body.Should().NotBe(command.Body);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
