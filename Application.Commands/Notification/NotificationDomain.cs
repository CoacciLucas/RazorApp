using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Notification;

public class NotificationDomain : INotification
{
    public DateTimeOffset Timestamp { get; private set; }

    public string MessageId { get; private set; }

    public string Message { get; private set; }

    public int AggregateId { get; private set; }

    public NotificationDomain(string message)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
    }

    public NotificationDomain(string messageId, string message)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
        MessageId = messageId;
    }

    public NotificationDomain(string messageId, string message, int aggregateId)
    {
        Timestamp = DateTimeOffset.Now;
        Message = message;
        MessageId = messageId;
        AggregateId = aggregateId;
    }
}
