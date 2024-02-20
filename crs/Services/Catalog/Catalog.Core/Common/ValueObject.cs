namespace Catalog.Core.Common;

public abstract class ValueObject
{
    public abstract IEnumerable<object> GetEqualityComponents();

    private bool ValueComponnetsEqual(ValueObject valueObject) => 
        valueObject.GetEqualityComponents().SequenceEqual(GetEqualityComponents());

    public override bool Equals(object? obj) =>
        obj is ValueObject valueObject && ValueComponnetsEqual(valueObject);

    public override int GetHashCode() =>
        GetEqualityComponents().Aggregate(default(int), HashCode.Combine);
}
