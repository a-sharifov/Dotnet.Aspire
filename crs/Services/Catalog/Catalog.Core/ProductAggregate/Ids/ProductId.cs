namespace Catalog.Core.ProductAggregate.Ids;

public record ProductId(Guid Value) : IStrongestId;
