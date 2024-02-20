namespace Catalog.Core.Common;

public interface IEntity<TStrongestId>
    where TStrongestId : IStrongestId
{
    public TStrongestId Id { get; }
}