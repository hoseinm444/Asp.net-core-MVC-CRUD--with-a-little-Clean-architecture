using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
public class InvoiceDetailDto : IInvoiceDetail, ISerializable
{
    public Guid Id { get; set; }
    [DataMember(Order = 1)]
    public string taxid { get; set; } = "AA56CD0E0620002F2B4E78";//1
    [DataMember(Order = 2)]
    public DateTime? indatim { get; set; } //2 invoice export
    [DataMember(Order = 3)]
    public DateTime? indati2 { get; set; } //3 invoice create
    [DataMember(Order = 4)]
    public int? inty { get; set; } = 2;//4 Invoice type 
    [DataMember(Order = 5)]
    public string inno { get; set; } = "0002F2B4E7";//5 invoice number
    [DataMember(Order = 6)]
    public string irtaxid { get; set; }  //شماره منحصر به فرد مالیاتی6 
    [DataMember(Order = 7)]
    public int? inp { get; set; } = 1;//7 invoice pattern
    [DataMember(Order = 8)]
    public int? ins { get; set; } = 1;//8 invoice subject
    [DataMember(Order = 9)]
    public long tins { get; set; } = 32652362589632;//9 of table 7
    [DataMember(Order = 10)]
    public int? tob { get; set; } = 1;//type of buyer
    [DataMember(Order = 11)]
    public int? bid { get; set; }//11 of table 7
    [DataMember(Order = 12)]
    public int? tinb { get; set; } //12
    [DataMember(Order = 13)]
    public int? sbc { get; set; }//13
    [DataMember(Order = 14)]
    public int? bpc { get; set; }//14
    [DataMember(Order = 15)]
    public int? bbc { get; set; }//15
    [DataMember(Order = 16)]
    public int? ft { get; set; }//flyght type
    [DataMember(Order = 17)]
    public string bpn { get; set; }//17
    [DataMember(Order = 18)]
    public int? scln { get; set; }//18
    [DataMember(Order = 19)]
    public int? scc { get; set; }//19
    [DataMember(Order = 20)]
    public int? crn { get; set; }//20

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}

