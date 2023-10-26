using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Infra.Data.Sql.Configs;

public class InvoiceHeaderConfig : EntityConfig<InvoiceHeader, Guid>
{
    public override void Configure(EntityTypeBuilder<InvoiceHeader> builder)
    {
        // builder
        //.HasOne(a => a.Service).WithOne(b => b.ApplicationRegister)
        //.HasForeignKey<ApplicationRegister<Service>>(b=>b.ServiceId).IsRequired();       

        builder.Ignore(p => p.DomainEvents);
        base.Configure(builder);
    }
}
