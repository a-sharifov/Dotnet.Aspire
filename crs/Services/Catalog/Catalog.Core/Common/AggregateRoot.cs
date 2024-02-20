namespace Catalog.Core.Common;

public abstract class AggregateRoot<TStrongestId> : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
    protected AggregateRoot() { }

    protected AggregateRoot(TStrongestId id) : base(id) { }
}
 