using Catalog.Core.ProductAggregate.Ids;

namespace Catalog.Core.ProductAggregate.DomainEvents;

public sealed record ProductCreatedDomainEvent(Guid Id, ProductId ProductId) : IDomainEvent;
