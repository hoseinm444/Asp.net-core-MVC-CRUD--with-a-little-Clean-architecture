using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Infra.Data.Sql.Repositories;
public class InvoiceHeaderRepository : IInvoiceHeaderRepository
{
    private readonly AccountingSubsystemContext context;

    public InvoiceHeaderRepository(AccountingSubsystemContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public IUnitOfWork UnitOfWork => context;


    public async Task<InvoiceHeader> AddAsync(IInoviceHeader header)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
            InvoiceHeader headerEntity = new InvoiceHeader(header);

            headerEntity.Create();
            var returnHeader = context.InvoiceHeaders.Add(headerEntity).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnHeader;
            else
                return null;
        }
    }

    public async Task<bool> DeleteAsync(IInoviceHeader header)
    {
        if (header is not null)
        {
            InvoiceHeader? entity = await context.InvoiceHeaders.FirstOrDefaultAsync<InvoiceHeader>(find => find.Id == header.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Delete();
                        context.Remove(entity);
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return true;
                        else
                            return false;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return false;
        }
        else
            return false;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var header = await context.InvoiceHeaders.FirstOrDefaultAsync<InvoiceHeader>(find => find.Id == id);
        return await DeleteAsync(header);
    }

    public async Task<IEnumerable<InvoiceHeader>> FindAllAsync()
    {
        var header = await context.InvoiceHeaders.Where(n => n.IsDeleted == false)
              .ToListAsync<InvoiceHeader>();
        return header;
    }

    public async Task<InvoiceHeader> FindByIdAsync(Guid id)
    {
        var header = await context.InvoiceHeaders.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return header;
    }

    public async Task<IEnumerable<InvoiceHeader>> FindByInputValueAsync(string search)
    {
        var header = await context.InvoiceHeaders.Where(n => n.Id.ToString() == search || n.From == search ||
        n.To == search || n.Subject == search )
             .ToListAsync<InvoiceHeader>();
        return header;
    }

    public async Task<InvoiceHeader> UpdateAsync(IInoviceHeader header)
    {
        if (header is not null)
        {
            InvoiceHeader? entity = await context
                .InvoiceHeaders
                .Where(find => find.Id == header.Id)
                .FirstOrDefaultAsync();
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        // context.Entry(company).State=EntityState.Modified;
                        entity.Update(header);
                        context.Update(entity);
                        if (await context.CommitTransactionAsync(transaction) > 0)
                            return entity;
                        else
                            return null;
                    }
                    catch
                    {
                        context.RollbackTransaction();
                        throw;
                    }
                }
            else
                return null;
        }
        else
            return null;
    }

    public async Task<InvoiceHeader> UpdateByIdAsync(Guid id)
    {
        InvoiceHeader? entity = await context
        .InvoiceHeaders
         .FirstOrDefaultAsync<InvoiceHeader>(find => find.Id == id);
        if (entity is not null)
            using (var transaction = await context.BeginTransactionAsync())
            {
                try
                {
                    //entity.Update(header);
                    context.Update(entity);
                    if (await context.CommitTransactionAsync(transaction) > 0)
                        return entity;
                    else
                        return null;
                }
                catch
                {
                    context.RollbackTransaction();
                    throw;
                }
            }
        else
            return null;
    }
}
