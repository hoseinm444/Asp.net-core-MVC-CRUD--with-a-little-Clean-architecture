namespace AccountingSubsystem.Infra.Data.Sql;

public static class ContextFactory
{
    public static AccountingSubsystemContext GetSqlContext()
    {
        var builder = new DbContextOptionsBuilder<AccountingSubsystemContext>();

        builder.UseSqlServer(@"Server=DESKTOP-01LMUME\SQL2019; Initial Catalog=AccountingSubsystem;Integrated Security=True;");
        return new AccountingSubsystemContext(builder.Options);


    }

}

