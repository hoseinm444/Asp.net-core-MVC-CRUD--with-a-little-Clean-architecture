using AccountingSubsystem.Domain.AggregatesModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
public interface IInvoiceHeaderRepository : IRepository<InvoiceHeader>
{
    Task<InvoiceHeader> AddAsync(IInoviceHeader header);
    Task<InvoiceHeader> UpdateAsync(IInoviceHeader header);
    Task<InvoiceHeader> UpdateByIdAsync(Guid id);

    Task<bool> DeleteAsync(IInoviceHeader header);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    Task<InvoiceHeader> FindByIdAsync(Guid id);
    // Task<CompanyDto> FindIdAsync(Guid id);
    Task<IEnumerable<InvoiceHeader>> FindAllAsync();
    Task<IEnumerable<InvoiceHeader>> FindByInputValueAsync(string search);
}
