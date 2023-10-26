using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;

public class InvoiceHeader : Entity, IAggregateRoot, IInoviceHeader
{
    public InvoiceHeader() { }

    public InvoiceHeader(IInoviceHeader header) : base(header.Id)
    {
        From = header.From ?? throw new ArgumentNullException(nameof(header.From));
        To = header.To ?? throw new ArgumentNullException(nameof(header.To));
        Price = header.Price;
        Subject = header.Subject ?? throw new ArgumentNullException(nameof(header.Subject));
        IssueDate = ConvertToShamsi((DateTime)header.IssueDate);
    }
    public InvoiceHeader(string from, string to, double price, string subject,
        DateTime issuedate/*,List<InvoiceDetail> commodity*/)
    {
        From = from;
        To = to;
        Price = price;
        Subject = subject;
        IssueDate = issuedate;
        //Commodity= commodity;
    }
    public Guid Id { get; private set; }
    public string From { get; private set; }
    public string To { get; private set; }
    public double Price { get; private set; }
    public string Subject { get; private set; }
    public DateTime IssueDate { get; private set; }
    // public List<InvoiceDetail> Commodity { get; private set; }
    public DateTime ConvertToShamsi(DateTime dateTime)
    {
        DateTime d = dateTime;
        PersianCalendar pc = new PersianCalendar();
        var persian = new DateTime(pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
        return persian;
    }
    public bool Update(IInoviceHeader invoice)
    {
        if (invoice is not null)
        {
            // Id= company.Id;
            From = invoice.From;
            To = invoice.To;
            Price = invoice.Price;
            Subject = invoice.Subject;
            IssueDate = invoice.IssueDate;

            base.Update();
            return true;
        }
        else
            return false;
    }
}
