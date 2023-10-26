using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingSubsystemIdentity.Models.InvoiceDetail;
public class UpdateInvoiceDetailViewModel
{
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "شماره منحصر به فرد مالیاتی")]
    public string taxid { get; set; }//1
    [DataType(DataType.Date)]   
    [Display(Name = "تاریخ و زمان صدور صورتحساب")]
    public DateTime? indatim { get; set; }//2 invoice export
    [DataType(DataType.Date)]
    [Display(Name = "تاریخ و زمان صدور صورتحساب")]
    public DateTime? indati2 { get; set; }//3 invoice create
    [Display(Name = "نوع صورت حساب")]
    public int? inty { get; set; }//4 Invoice type 
    [Display(Name = "سریال صورت حساب")]
    public string inno { get; set; }//5 invoice number
    [Display(Name = "شماره منحصر به فرد مالیاتی صورتحساب مرجع")]
    public string irtaxid { get; set; }  //شماره منحصر به فرد مالیاتی6 
    [Display(Name = "الگوی صورتحساب")]
    public int? inp { get; set; }//7 invoice pattern
    [Display(Name = "موضوع صورتحساب")]
    public int? ins { get; set; }//8 invoice subject
    [Display(Name = "نوع شخص خریدار")]
    public long tins { get; set; }//9 of table 7
    [Display(Name = "شماره/شناسه ملی/شناسه مشاركت مدنی/كد فراگیر خریدار")]
    public int? tob { get; set; }//type of buyer
    [Display(Name = "شماره اقتصادی خریدار")]
    public int? bid { get; set; }//11 of table 7
    [Display(Name = "تاریخ و زمان صدور صورتحساب ")]
    public int? tinb { get; set; } //12
    [Display(Name = "كد شعبه فروشنده")]
    public int? sbc { get; set; }//13
    [Display(Name = "كد پستی خریدار")]
    public int? bpc { get; set; }//14
    [Display(Name = "كد شعبه خریدار")]
    public int? bbc { get; set; }//15
    [Display(Name = "نوع پرواز")]
    public int? ft { get; set; }//flyght type
    [Display(Name = "شماره گذرنامه خریدار")]
    public string bpn { get; set; }//17
    [Display(Name = "شماره پروانه گمركی فروشنده")]
    public int? scln { get; set; }//18
    [Display(Name = "كد گمرک محل اظهار")]
    public int? scc { get; set; }//19
    [Display(Name = "شناسه یکتای ثبت قرارداد فروشنده")]
    public int? crn { get; set; }//20
}

