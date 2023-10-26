using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace AccountingSubsystem.Domain.AggregatesModel.Company;
public class Company : Entity, IAggregateRoot, ICompany
{
    public Company() { }

    public Company(ICompany company) : base(company.Id)
    {
         // Id = company.Id;
        CompanyName = company.CompanyName ?? throw new ArgumentNullException(nameof(company.CompanyName));
        CompanyCode = company.CompanyCode ?? throw new ArgumentNullException(nameof(company.CompanyCode));
        EconomicCode = company.EconomicCode ?? throw new ArgumentNullException(nameof(company.EconomicCode));
        CompanyAddress = company.CompanyAddress ?? throw new ArgumentNullException(nameof(company.CompanyAddress));
        CompanyPhoneNumber = company.CompanyPhoneNumber ?? throw new ArgumentNullException(nameof(company.CompanyPhoneNumber));
    }

    public  Guid Id { get; private set; }
    [Display(Name = "نام شرکت")]
    public string CompanyName { get; private set; }
    [Display(Name = "کد شرکت")]
    public string CompanyCode { get; private set; }
    [Display(Name = "کد اقتصادی")]
    public string EconomicCode { get; private set; }
    [Display(Name = "آدرس شرکت")]
    public string CompanyAddress { get; private set; }
    [Display(Name = "شماره تلفن شرکت")]
    public string CompanyPhoneNumber { get; private set; }


    //Guid ICompany.Id => throw new NotImplementedException();

    public bool Update(ICompany company)
    {
        if (company is not null)
        {
            // Id= company.Id;
            //Id= company.Id;
            CompanyName = company.CompanyName;
            CompanyCode = company.CompanyCode;
            EconomicCode = company.EconomicCode;
            CompanyAddress = company.CompanyAddress;
            CompanyPhoneNumber = company.CompanyPhoneNumber;

            base.Update();
            return true;
        }
        else
            return false;
    }
    public Company UpdateDTO(ICompany company)
    {
        if (company is not null)
        {
            // Id = company.Id;
            var companyEn = new Company()
            {
                //Id= company.Id,
                CompanyName = company.CompanyName,
                CompanyCode = company.CompanyCode,
                EconomicCode = company.EconomicCode,
                CompanyAddress = company.CompanyAddress,
                CompanyPhoneNumber = company.CompanyPhoneNumber,
            };
            //Id = company.Id;


            base.Update();
            return companyEn;
        }
        else
            return null;

    }

}
