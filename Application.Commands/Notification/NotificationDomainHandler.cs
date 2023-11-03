using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Notification
{
    public class NotificationDomainHandler : INotificationHandler<NotificationDomain>
    {
        private List<NotificationDomain> _notifications;

        public Task Handle(NotificationDomain notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public NotificationDomainHandler()
        {
            _notifications = new List<NotificationDomain>();
        }

        public virtual List<NotificationDomain> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<NotificationDomain>();
        }
    }

}
