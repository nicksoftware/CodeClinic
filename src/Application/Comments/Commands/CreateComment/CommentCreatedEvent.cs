using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Comments.Commands.CreateComment
{
    public class CommentCreatedEvent : INotification
    {
        public int Id { get; set; }

        public class CommentCreatedEventHandler : INotificationHandler<CommentCreatedEvent>
        {
            public Task Handle(CommentCreatedEvent notification, CancellationToken cancellationToken)
            {
                //DO something

                throw new NotImplementedException();
            }
        }
    }

}
