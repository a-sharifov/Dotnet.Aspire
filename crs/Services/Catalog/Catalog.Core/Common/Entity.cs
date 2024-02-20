namespace Catalog.Core.Common;

public abstract class Entity<TStrongestId> : 
    IEntity<TStrongestId>,
    IHasDomainEvents
    where TStrongestId : IStrongestId
  
{
    public virtual TStrongestId Id { get; protected set; }
    private readonly IList<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected Entity(TStrongestId id) => Id = id;

    public static bool operator ==(Entity<TStrongestId>? left, Entity<TStrongestId>? right) => 
        left != null && left.Equals(right);

    public static bool operator !=(Entity<TStrongestId>? left, Entity<TStrongestId>? right) => 
        !(left == right);

    public void Raise(IDomainEvent @event) => _domainEvents.Add(@event);

    public void ClearDomainEvents() => _domainEvents.Clear();

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj is not Entity<TStrongestId> entity)
        {
            return false;
        }

        return Id.Value == entity.Id.Value;
    }

    public override int GetHashCode() =>
        Id.Value.GetHashCode();
}
