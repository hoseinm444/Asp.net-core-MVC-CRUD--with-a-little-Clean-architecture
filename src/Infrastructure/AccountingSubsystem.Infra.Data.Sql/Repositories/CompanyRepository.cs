

using AccountingSubsystem.Domain.AggregatesModel.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AccountingSubsystem.Infra.Data.Sql.Repositories;
public class CompanyRepository : ICompanyRepository
{
    private readonly AccountingSubsystemContext context;

    public CompanyRepository(AccountingSubsystemContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => context;

    public async Task<Company> AddAsync(ICompany header)
    {
        using (var transaction = await context.BeginTransactionAsync())
        {
            Company headerEntity = new Company(header);

            headerEntity.Create();
            var returnHeader = context.Companies.Add(headerEntity).Entity;
            if (await context.CommitTransactionAsync(transaction) > 0)
                return returnHeader;
            else
                return null;
        }
    }

   

    public async Task<bool> DeleteAsync(ICompany header)
    {
        if (header is not null)
        {
            Company? entity = await context.Companies.FirstOrDefaultAsync<Company>(find => find.Id == header.Id);
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        entity.Delete();
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
        var header = await context.Companies.FirstOrDefaultAsync<Company>(find => find.Id == id);
        return await DeleteAsync(header);
    }

    public async Task<IEnumerable<Company>> FindAllAsync()
    {
        var header = await context
            .Companies
            .Where(n => n.IsDeleted == false)
            .OrderBy(n => n.Id)
             .ToListAsync<Company>();
        return header;
    }

    //public async Task<IQueryable<Company>> FindAllQueryableAsync()
    //{
    //    var header = await context
    //        .Companies
    //        .Where(n => n.IsDeleted == false)
    //        .OrderBy(n => n.Id)
    //         .ToListAsync<Company>();
    //    return (IQueryable<Company>)header;
    //}

    public async Task<Company> FindByIdAsync(Guid id)
    {
        var header = await context.Companies.Where(a => a.Id == id)
            .FirstOrDefaultAsync();
        return header;
    }

    public async Task<IEnumerable<Company>> FindByInputValueAsync(string search)
    {
        var header = await context.Companies.Where(n => n.Id.ToString()==search|| n.CompanyName == search ||
        n.CompanyCode==search||n.CompanyAddress==search||n.EconomicCode==search||
        n.CompanyPhoneNumber==search)
             .ToListAsync<Company>();
        return header;
    }
    public async Task<Company> UpdateAsync(ICompany company)
    {
        if (company is not null)
        {
            Company? entity = await context
                .Companies
                .Where(find => find.Id == company.Id)
                .FirstOrDefaultAsync();
            if (entity is not null)
                using (var transaction = await context.BeginTransactionAsync())
                {
                    try
                    {
                        // context.Entry(company).State=EntityState.Modified;
                        entity.Update(company);
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



    public async Task<Company> UpdateByIdAsync(Guid id)
    {
            Company? entity = await context
            .Companies
            .AsNoTracking()
             .FirstOrDefaultAsync<Company>(find => find.Id == id);
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

