namespace AccountingSubsystem.SeedWork.Domain;
public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
