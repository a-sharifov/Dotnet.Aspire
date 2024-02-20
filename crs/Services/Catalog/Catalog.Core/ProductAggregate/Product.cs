using Catalog.Core.ProductAggregate.DomainEvents;
using Catalog.Core.ProductAggregate.Ids;

namespace Catalog.Core.ProductAggregate;

public class Product : AggregateRoot<ProductId>
{
    public string Name { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Product() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Product(ProductId id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Product Create(ProductId id, string name)
    {
        Product product = new(id, name);
        product.Raise(
            new ProductCreatedDomainEvent(Guid.NewGuid(), id));

        return product;
    } 
}