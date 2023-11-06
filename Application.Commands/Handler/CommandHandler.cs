using Application.Commands.Notification;
using Domain.Entities.Core;
using FluentValidation.Results;
using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Handler;

public abstract class CommandHandler
{
    protected readonly IUnitOfWork _uow;

    protected readonly IMediator _mediator;

    protected readonly INotificationHandler<NotificationDomainT> _notifications;

    protected readonly ILogger<CommandHandler> _logger;

    public CommandHandler()
    {
    }

    public CommandHandler(IMediator mediator, INotificationHandler<NotificationDomainT> notifications)
    {
        _mediator = mediator;
        _notifications = notifications;
    }

    public CommandHandler(IUnitOfWork uow, IMediator mediator, INotificationHandler<NotificationDomainT> notifications)
    {
        _uow = uow;
        _mediator = mediator;
        _notifications = notifications;
    }

    public CommandHandler(IUnitOfWork uow, IMediator mediator, INotificationHandler<NotificationDomainT> notifications, ILogger<CommandHandler> logger = null)
    {
        _uow = uow;
        _mediator = mediator;
        _notifications = notifications;
        _logger = logger;
    }

    protected async void HandleEntity(Entity entity)
    {
        if (entity == null)
        {
            return;
        }

        foreach (ValidationFailure error in entity.ValidationResult.Errors)
        {
            await _mediator.Publish(new NotificationDomainT(error.PropertyName, error.ErrorMessage));
        }
    }

    protected async void HandleEntities(IEnumerable<Entity> entities)
    {
        if (entities == null)
        {
            return;
        }

        foreach (Entity entity in entities)
        {
            foreach (ValidationFailure error in entity.ValidationResult.Errors)
            {
                await _mediator.Publish(new NotificationDomainT(error.PropertyName, error.ErrorMessage));
            }
        }
    }

    protected async void AddNotification(string key, string message)
    {
        var notificationDomain = new NotificationDomainT(key, message);
        await _mediator.Publish(notificationDomain);
    }

    public async void AddNotification(NotificationDomainT notification)
    {
        await _mediator.Publish(new NotificationDomainT(notification.MessageId, notification.Message));
    }

    public async void AddNotifications(IReadOnlyCollection<NotificationDomainT> notifications)
    {
        foreach (NotificationDomainT notification in notifications)
        {
            await _mediator.Publish(new NotificationDomainT(notification.MessageId, notification.Message));
        }
    }

    public async void AddNotifications(IList<NotificationDomainT> notifications)
    {
        foreach (NotificationDomainT notification in notifications)
        {
            await _mediator.Publish(new NotificationDomainT(notification.MessageId, notification.Message));
        }
    }

    public async void AddNotifications(ICollection<NotificationDomainT> notifications)
    {
        foreach (NotificationDomainT notification in notifications)
        {
            await _mediator.Publish(new NotificationDomainT(notification.MessageId, notification.Message));
        }
    }

    protected bool IsSuccess()
    {
        return !((NotificationDomainTHandler)_notifications).HasNotifications();
    }

    protected List<NotificationDomainT> DomainNotifications()
    {
        return ((NotificationDomainTHandler)_notifications).GetNotifications();
    }

    protected async Task CommittAsync()
    {
        _logger.LogTrace("Is Success Domain Notificações", IsSuccess());
        if (IsSuccess())
        {
            await _uow.CommitAsync();
            _logger.LogTrace("Is Commit DataBase", true);
        }
    }
}
