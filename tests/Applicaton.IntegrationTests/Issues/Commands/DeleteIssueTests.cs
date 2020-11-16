using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Issues.Commands.DeleteIssue;
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
    public class DeleteIssueTests :TestBase
    {

        [Test]
        public void WhenDeleteIssueCommand_Called_ShouldRequireValidIssueId()
        {
            var command = new DeleteIssueTicketCommand { Id = 99};

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public void WhenDeleteCommandCalled_With_NegativeIssueId_ShouldRequireValidId()
        {
            var command = new DeleteIssueTicketCommand { Id = -1 };

            FluentActions.Invoking(() =>
            SendAsync(command)).Should().Throw<IndexOutOfRangeException>();
        }


    }
}
