using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;

namespace AccountingSubsystem.Infra.Data.Sql.Configs;

public class InvoiceDetailConfig : EntityConfig<InvoiceDetail, Guid>
{
    public override void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        //builder.HasQueryFilter(c => c.IsDeleted == false);
        //builder.HasKey(a => a.Id);

        builder.Property(p => p.taxid).HasMaxLength(22);
        builder.Property(p => p.indatim).HasMaxLength(14);
        builder.Property(p => p.indati2).HasMaxLength(14);
        builder.Property(p => p.inty).HasMaxLength(1);
        builder.Property(p => p.inno).HasMaxLength(10);
        builder.Property(p => p.irtaxid).HasMaxLength(22);
        builder.Property(p => p.inp).HasMaxLength(1);
        builder.Property(p => p.ins).HasMaxLength(1);
        builder.Property(p => p.tins).HasMaxLength(10);
        builder.Property(p => p.tob).HasMaxLength(1);
        builder.Property(p => p.tinb).HasMaxLength(10);
        builder.Property(p => p.bpc).HasMaxLength(10);
        builder.Property(p => p.ft).HasMaxLength(1);


        // builder
        //.HasOne(a => a.Service).WithOne(b => b.ApplicationRegister)
        //.HasForeignKey<ApplicationRegister<Service>>(b=>b.ServiceId).IsRequired();       

        builder.Ignore(p => p.DomainEvents);
         base.Configure(builder);
    }
}

