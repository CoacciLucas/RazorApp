using MediatR;

namespace Application.Commands.Notification
{
    public class NotificationDomainTHandler : INotificationHandler<NotificationDomainT>
    {
        private List<NotificationDomainT> _notifications;

        public Task Handle(NotificationDomainT notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public NotificationDomainTHandler()
        {
            _notifications = new List<NotificationDomainT>();
        }

        public virtual List<NotificationDomainT> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<NotificationDomainT>();
        }
    }

}
