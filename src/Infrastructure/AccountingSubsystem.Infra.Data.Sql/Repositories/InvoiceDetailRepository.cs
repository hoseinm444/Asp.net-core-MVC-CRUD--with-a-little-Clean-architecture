using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
using Microsoft.EntityFrameworkCore;

namespace AccountingSubsystem.Infra.Data.Sql.Repositories;
public class InvoiceDetailRepository :IInvoiceDetailRepository
{
    private readonly AccountingSubsystemContext context;

    public InvoiceDetailRepository(AccountingSubsystemContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => context;

    public async Task<InvoiceDetail> AddAsync(IInvoiceDetail header)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
            InvoiceDetail headerEntity = new InvoiceDetail(header);

            headerEntity.Create();
            var returnHeader = context.InvoiceDetails.Add(headerEntity).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnHeader;
            else
                return null;
        }
    }

    public async Task<bool> DeleteAsync(IInvoiceDetail header)
    {
        if (header is not null)
        {
            InvoiceDetail? entity = await context.InvoiceDetails.FirstOrDefaultAsync<InvoiceDetail>(find => find.irtaxid == header.irtaxid);
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
        var header = await context.InvoiceDetails.FirstOrDefaultAsync<InvoiceDetail>(find => find.Id == id);
        return await DeleteAsync(header);
    }

    public async Task<IEnumerable<InvoiceDetail>> FindAllAsync()
    {
        var header = await context.InvoiceDetails.Where(n => n.IsDeleted == false)
             .ToListAsync<InvoiceDetail>();
        return header;
    }

    public async Task<InvoiceDetail> FindByIdAsync(Guid id)
    {
        var header = await context.InvoiceDetails.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return header;
    }

    public async Task<IEnumerable<InvoiceDetail>> FindByInputValueAsync(string search)
    {
        var header = await context.InvoiceDetails.Where(n => n.Id.ToString() == search || n.taxid == search ||
       n.indatim.ToString() == search || n.irtaxid == search || n.ins.ToString() == search ||
       n.bid.ToString() == search)
            .ToListAsync<InvoiceDetail>();
        return header;
    }

    public async Task<InvoiceDetail> UpdateAsync(IInvoiceDetail header)
    {
        if (header is not null)
        {
            InvoiceDetail? entity = await context
                .InvoiceDetails
                .FirstOrDefaultAsync<InvoiceDetail>(find => find.Id == header.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
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
}

