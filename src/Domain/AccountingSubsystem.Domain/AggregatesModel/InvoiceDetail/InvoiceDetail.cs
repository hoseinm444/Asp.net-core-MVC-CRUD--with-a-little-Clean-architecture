

using AccountingSubsystem.Domain.AggregatesModel.Company;
using System.Globalization;
using System.Runtime.Serialization;

namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
public class InvoiceDetail : Entity, IAggregateRoot, IInvoiceDetail
{
    public InvoiceDetail() { }

    public InvoiceDetail(IInvoiceDetail header) : base(header.Id)
    {
        taxid = header.taxid;
        indatim = ConvertToShamsi((DateTime)header.indatim);
        indati2 = ConvertToShamsi((DateTime)header.indati2);
        inty = header.inty;
        inno = header.inno;
        irtaxid = header.irtaxid;
        inp = header.inp;
        ins = header.ins;
        tins = header.tins;
        tob = header.tob;
        bid = header.bid;
        tinb = header.tinb;
        sbc = header.sbc;
        bpc = header.bpc;
        bbc = header.bbc;
        ft = header.ft;
        bpn = header.bpn;
        scln = header.scln;
        scc = header.scc;
        crn = header.crn;
    }

    public InvoiceDetail(string taxid, DateTime indatim, DateTime indati2,
        int inty, string inno, string irtaxid, int inp, int ins, int tins,
        int tob, int bid, int tinb, int sbc, int bpc, int bbc, int ft,
        string bpn, int scln, int scc, int crn)
    {
        this.taxid = taxid;
        this.indatim = ConvertToShamsi(indatim);
        this.indati2 = ConvertToShamsi(indati2);
        this.inty = inty;
        this.inno = inno;
        this.irtaxid = irtaxid;
        this.inp = inp;
        this.ins = ins;
        this.tins = tins;
        this.tob = tob;
        this.bid = bid;
        this.tinb = tinb;
        this.sbc = sbc;
        this.bpc = bpc;
        this.bbc = bbc;
        this.ft = ft;
        this.bpn = bpn;
        this.scln = scln;
        this.scc = scc;
        this.crn = crn;
    }

    public Guid Id { get; private set; }
    public string taxid { get; private set; }//1
    public DateTime? indatim { get; private set; }//2 invoice export
    public DateTime? indati2 { get; private set; }//3 invoice create
    public int? inty { get; private set; }//4 Invoice type 
    public string inno { get; private set; }//5 invoice number
    public string irtaxid { get; private set; }  //شماره منحصر به فرد مالیاتی6 
    public int? inp { get; private set; }//7 invoice pattern
    public int? ins { get; private set; }//8 invoice subject
    public long tins { get; private set; }//9 of table 7
    public int? tob { get; private set; }//type of buyer
    public int? bid { get; private set; }//11 of table 7
    public int? tinb { get; private set; } //12
    public int? sbc { get; private set; }//13
    public int? bpc { get; private set; }//14
    public int? bbc { get; private set; }//15
    public int? ft { get; private set; }//flyght type
    public string bpn { get; private set; }//17
    public int? scln { get; private set; }//18
    public int? scc { get; private set; }//19
    public int? crn { get; private set; }//20

    public DateTime ConvertToShamsi(DateTime dateTime)
    {
        DateTime d = dateTime;
        PersianCalendar pc = new PersianCalendar();
        var persian= new DateTime( pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
        return persian;
    }

    public bool Update(IInvoiceDetail invoice)
    {
        if (invoice is not null)
        {
            taxid = invoice.taxid;
            indatim = invoice.indatim;
            indati2 = invoice.indati2;
            inty = invoice.inty;
            inno = invoice.inno;
            irtaxid = invoice.irtaxid;
            inp = invoice.inp;
            ins = invoice.ins;
            tins = invoice.tins;
            tob = invoice.tob;
            bid = invoice.bid;
            tinb = invoice.tinb;
            sbc = invoice.sbc;
            bpc = invoice.bpc;
            bbc = invoice.bbc;
            ft = invoice.ft;
            bpn = invoice.bpn;
            scln = invoice.scln;
            scc = invoice.scc;
            crn = invoice.crn;

            base.Update();
            return true;
        }
        else
            return false;
    }
}

