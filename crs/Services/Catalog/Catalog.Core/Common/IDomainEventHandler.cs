namespace Catalog.Core.Common;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent> 
    where TDomainEvent : IDomainEvent
{
}
