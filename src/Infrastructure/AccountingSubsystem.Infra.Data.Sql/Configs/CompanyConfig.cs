using AccountingSubsystem.Domain.AggregatesModel.Company;


namespace AccountingSubsystem.Infra.Data.Sql.Configs;
public class CompanyConfig : EntityConfig<Company, Guid>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {

        //builder.Property(p => p.taxid).HasMaxLength(22);
        //builder.Property(p => p.indatim).HasMaxLength(14);
        //builder.Property(p => p.indati2).HasMaxLength(14);

        builder.Ignore(p => p.DomainEvents);
        base.Configure(builder);
    }
}

