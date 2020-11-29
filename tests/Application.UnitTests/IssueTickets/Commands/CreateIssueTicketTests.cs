using Application.Issues.Commands.CreateIssue;
using CodeClinic.Application.UnitTests.Common;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeClinic.Application.UnitTests.IssueTickets.Commands
{
    public class CreateIssueTicketTests : CommandTestBase
    {
        public void Handle_GivenValidRequest_ShouldRaiseIssueTicketCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();

            var handler = new CreateIssueTicketCommand.CreateIssueTicketCommandHandler(_context);

            var newIssueId = 4;

            // Act
            var result = handler.Handle(new CreateIssueTicketCommand { Id = newIssueId }, CancellationToken.None);


            // Assert
        //    mediatorMock.Verify(m => m.Publish(It.Is<CustomerCreated>(cc => cc.Id == newIssueId), It.IsAny<CancellationToken>()), Times.Once);
          
        }
    }
}
