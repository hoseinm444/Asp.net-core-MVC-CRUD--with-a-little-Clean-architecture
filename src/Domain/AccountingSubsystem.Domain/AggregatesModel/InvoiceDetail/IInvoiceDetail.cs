using JsonApiDotNetCore.Resources;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
public interface IInvoiceDetail
{

    public Guid Id { get; }
    public string taxid { get; }//1
    public DateTime? indatim { get; }//2 invoice export
    public DateTime? indati2 { get; }//3 invoice create
    public int? inty { get; }//4 Invoice type 
    public string inno { get; }//5 invoice number
    public string irtaxid { get; }  //شماره منحصر به فرد مالیاتی6 - id for each invoice 
    public int? inp { get; }//7 invoice pattern
    public int? ins { get; }//8 invoice subject
    public long tins { get; }//9 of table 7
    public int? tob { get; }//type of buyer
    public int? bid { get; }//11 of table 7
    public int? tinb { get; } //12
    public int? sbc { get; }//13
    public int? bpc { get; }//14
    public int? bbc { get; }//15
    public int? ft { get; }//flyght type
    public string bpn { get; }//17
    public int? scln { get; }//18
    public int? scc { get; }//19
    public int? crn { get; }//20
}

