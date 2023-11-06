using MediatR;

namespace Application.Commands.Notification;

public class NotificationDomainT : INotification
{
    public DateTimeOffset Timestamp { get; private set; }

    public string MessageId { get; private set; }

    public string Message { get; private set; }

    public int AggregateId { get; private set; }

    public NotificationDomainT(string message)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
    }

    public NotificationDomainT(string messageId, string message)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
        MessageId = messageId;
    }

    public NotificationDomainT(string messageId, string message, int aggregateId)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
        MessageId = messageId;
        AggregateId = aggregateId;
    }
}
