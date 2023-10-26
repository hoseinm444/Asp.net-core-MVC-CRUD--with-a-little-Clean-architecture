using System.ComponentModel.DataAnnotations;


namespace AccountingSubsystem.Domain.AggregatesModel.Company;
public interface ICompany
{
    public  Guid Id { get; }
    [Display(Name = "نام شرکت")]
    public string CompanyName { get; }
    [Display(Name = "کد شرکت")]
    public string CompanyCode { get; }
    [Display(Name = "کد اقتصادی")]
    public string EconomicCode { get; }
    [Display(Name = "آدرس شرکت")]
    public string CompanyAddress { get; }
    [Display(Name = "شماره تلفن شرکت")]
    public string CompanyPhoneNumber { get; }

}
