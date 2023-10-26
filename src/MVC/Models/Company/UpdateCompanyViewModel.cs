using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingSubsystemIdentity.Models.Company;
public class UpdateCompanyViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "نام شرکت")]
    public string CompanyName { get; set; }
    [Display(Name = "کد شرکت")]
    public string CompanyCode { get; set; }
    [Display(Name = "کد اقتصادی")]
    public string EconomicCode { get; set; }
    [Display(Name = "آدرس شرکت")]
    public string CompanyAddress { get; set; }
    [Display(Name = "شماره تلفن شرکت")]
    public string CompanyPhoneNumber { get; set; }
}

