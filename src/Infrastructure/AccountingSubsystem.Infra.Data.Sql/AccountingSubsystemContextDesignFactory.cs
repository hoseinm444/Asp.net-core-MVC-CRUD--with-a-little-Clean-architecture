using Microsoft.EntityFrameworkCore.Design;

namespace AccountingSubsystem.Infra.Data.Sql;
public class AccountingSubsystemContextDesignFactory :  IDesignTimeDbContextFactory<AccountingSubsystemContext>
{
    public AccountingSubsystemContext CreateDbContext(string[] args) => ContextFactory.GetSqlContext();

    
}

