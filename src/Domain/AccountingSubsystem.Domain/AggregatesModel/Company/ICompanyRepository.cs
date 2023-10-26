namespace AccountingSubsystem.Domain.AggregatesModel.Company;
public interface ICompanyRepository : IRepository<Company>
{
    Task<Company> AddAsync(ICompany company);
    Task<Company> UpdateAsync(ICompany company);
   // Task<Company> UpdateAsync(Guid id,ICompany company);
    Task<Company> UpdateByIdAsync(Guid id);

    Task<bool> DeleteAsync(ICompany company);
    Task<bool> DeleteByIdAsync(Guid id);

    //read 
    Task<Company> FindByIdAsync(Guid id);
   // Task<CompanyDto> FindIdAsync(Guid id);
    Task<IEnumerable<Company>> FindAllAsync();
    Task<IEnumerable<Company>> FindByInputValueAsync(string search);

    //grid
    //Task<IQueryable<Company>> FindAllQueryableAsync();

}
