namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
{

    Task<InvoiceDetail> AddAsync(IInvoiceDetail invoice);
    Task<InvoiceDetail> UpdateAsync(IInvoiceDetail invoice);

    Task<bool> DeleteAsync(IInvoiceDetail invoice);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    Task<InvoiceDetail> FindByIdAsync(Guid id);
    Task<IEnumerable<InvoiceDetail>> FindAllAsync();
    Task<IEnumerable<InvoiceDetail>> FindByInputValueAsync(string? search);
}


