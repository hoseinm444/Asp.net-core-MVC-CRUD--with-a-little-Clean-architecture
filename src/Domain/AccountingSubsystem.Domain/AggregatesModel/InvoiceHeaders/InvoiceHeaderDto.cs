using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
public class InvoiceHeaderDto : IInoviceHeader, ISerializable
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
    //public List<InvoiceDetail> Commodity { get; set; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}
