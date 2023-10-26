//using AccountingSubsystemIdentity.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AccountingSubsystem.Domain.AggregatesModel.Identity;
using System.Data;
using System.Reflection;
using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;

namespace AccountingSubsystem.Infra.Data.Sql;
public class AccountingSubsystemContext : /*DbContext,*/ IdentityDbContext<ApplicationUser>, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "AccountingSubSystem";
    //public DbSet<InvoiceBody> Bodies => Set<InvoiceBody>();
    public DbSet<InvoiceDetail> InvoiceDetails=>Set<InvoiceDetail>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<InvoiceHeader> InvoiceHeaders => Set<InvoiceHeader>();

    private readonly IMediator _mediator;

    public AccountingSubsystemContext(DbContextOptions<AccountingSubsystemContext> options) : base(options) { }
    //make database transaction 
    private IDbContextTransaction? _currentTransaction;

    public AccountingSubsystemContext(DbContextOptions<AccountingSubsystemContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("AccountingSubSystem");

        modelBuilder.ApplyConfiguration(new InvoiceDetailConfig());
        //modelBuilder.ApplyConfiguration(new InvoiceBodyConfig());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public bool HasActiveTransaction => _currentTransaction is not null;

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

        //await _mediator.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        var result = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task<int> CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        int result = default(int);
        try
        {
            result = await SaveChangesAsync();
            transaction.Commit();
            return result;
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }


}

