using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.IssueTickets.Commands.CreateIssueTicket
{
    class IssueTicketCreatedEvent : INotification
    {
        public int IssueTicketId { get; set; }

        public class IssueTicketCreatedEventHandler : INotificationHandler<IssueTicketCreatedEvent>
        {
            public Task Handle(IssueTicketCreatedEvent notification, CancellationToken cancellationToken)
            {
                // do something
                throw new NotImplementedException();
            }
        }
    }
}
