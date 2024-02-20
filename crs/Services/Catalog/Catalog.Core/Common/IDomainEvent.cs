namespace Catalog.Core.Common;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
}
