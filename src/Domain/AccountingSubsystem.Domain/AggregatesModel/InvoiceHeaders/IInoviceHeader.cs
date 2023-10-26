
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
public interface IInoviceHeader
{
    public Guid Id { get; }
    public string From { get; }
    public string To { get; }
    public double Price { get; }
    public string Subject { get; }
    public DateTime IssueDate { get; }
    //public List<InvoiceDetail> Commodity { get; }
}
