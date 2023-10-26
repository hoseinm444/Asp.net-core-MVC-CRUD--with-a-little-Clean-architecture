using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingSubsystemIdentity.Models.InvoiceHeader;

public class UpdateInvoiceHeaderViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "فاکتور از:")]
    public string From { get; set; }
    [Display(Name = "فاکتور به:")]
    public string To { get; set; }
    [Display(Name = "قیمت")]
    public double Price { get; set; }
    [Display(Name = "موضوع فاکتور")]
    public string Subject { get; set; }
    [Display(Name = "تاریخ صدور:")]
    public DateTime IssueDate { get; set; }
}
