using AccountingSubsystem.Domain.AggregatesModel;
using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceDetail;
using AccountingSubsystemIdentity.Models.Company;
using AccountingSubsystemIdentity.Models.InvoiceDetail;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Net.Pkcs11Interop.Common;
using System.Security.Cryptography;
using static Duende.IdentityServer.Models.IdentityResources;

namespace AccountingSubsystemIdentity.Controllers;
public class InvoiceDetailController : Controller
{
    private readonly IInvoiceDetailRepository _repository;
    public InvoiceDetailController(IInvoiceDetailRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> CRUDInvoiceDetail(int page=1)
    {
        var invoice = await _repository.FindAllAsync();
        const int pageSize = 10;
        if (page < 1)
            page = 1;
        int rescCount = invoice.Count();
        var pager = new PagedList(rescCount, page, pageSize);
        int recSkip = (page - 1) * pageSize;
        var data = invoice.Skip(recSkip).Take(pager.PageSize).ToList();
        this.ViewBag.Pager = pager;
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> CRUDInvoiceDetail(string search)
    {
        if (search is not null)
        {
            var invoice = await _repository.FindByInputValueAsync(search);
            return View(invoice);
        }
        else
        {
            var invoice = await _repository.FindAllAsync();
            return View(invoice);
        }
    }
    [HttpGet]
    public IActionResult CreateInvoiceDetail()
    {
        return View();
    }

    [HttpPost/*("Create")*/]
    public async Task<IActionResult> CreateInvoiceDetail(InvoiceDetailViewModel invoice)
    {
        var detail = new InvoiceDetailDto()
        {
            taxid = invoice.taxid,
            indatim = invoice.indatim,
            indati2 = invoice.indati2,
            inty = invoice.inty,
            inno = invoice.inno,
            irtaxid = invoice.irtaxid,
            inp = invoice.inp,
            ins = invoice.ins,
            tins = invoice.tins,
            tob = invoice.tob,
            bid = invoice.bid,
            tinb = invoice.tinb,
            sbc = invoice.sbc,
            bpc = invoice.bpc,
            bbc = invoice.bbc,
            ft = invoice.ft,
            bpn = invoice.bpn,
            scln = invoice.scln,
            scc = invoice.scc,
            crn = invoice.crn
        };

        await _repository.AddAsync(detail);
        return RedirectToAction("CRUDInvoiceDetail");
    }

    // To fill data in the form
    // to enable easy editing
    //[Route("UpdateCompany/{id:Guid}")]
    [HttpGet]
    public async Task<IActionResult> UpdateInvoiceDetail(Guid id)
    {
        var detail = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (detail is not null)
        {
            var viewmodel = new UpdateInvoiceDetailViewModel()
            {
                // Id = compny.Id,
                taxid = detail.taxid,
                indatim = detail.indatim,
                indati2 = detail.indati2,
                inty = detail.inty,
                inno = detail.inno,
                irtaxid = detail.irtaxid,
                inp = detail.inp,
                ins = detail.ins,
                tins = detail.tins,
                tob = detail.tob,
                bid = detail.bid,
                tinb = detail.tinb,
                sbc = detail.sbc,
                bpc = detail.bpc,
                bbc = detail.bbc,
                ft = detail.ft,
                bpn = detail.bpn,
                scln = detail.scln,
                scc = detail.scc,
                crn = detail.crn
            };
            //   await _repository.UpdateByIdAsync(id);
            return View(viewmodel);
        }
        return RedirectToAction("CRUDInvoiceDetail");
    }

    // To specify that this will be
    // invoked when post method is called
    [HttpPost]
    public async Task<IActionResult> UpdateInvoiceDetail(/*Guid id,*/InvoiceDetailDto model)
    {
        // Checking if any such record exist
        if (model != null)
        {

            await _repository.UpdateAsync(model);

            // It will redirect to
            // the Read method
            return RedirectToAction("CRUDInvoiceDetail");
        }
        else
            return RedirectToAction("CRUDInvoiceDetail");
    }
    [HttpGet]
    public async Task<IActionResult> DeleteInvoiceDetail(Guid id)
    {
        // var companyGuidid = Guid.Parse(companyid);
        var detail = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (detail is not null)
        {
            var viewmodel = new DeleteInvoiceDetailViewModel()
            {
                // Id = compny.Id,
                taxid = detail.taxid,
                indatim = detail.indatim,
                indati2 = detail.indati2,
                inty = detail.inty,
                inno = detail.inno,
                irtaxid = detail.irtaxid,
                inp = detail.inp,
                ins = detail.ins,
                tins = detail.tins,
                tob = detail.tob,
                bid = detail.bid,
                tinb = detail.tinb,
                sbc = detail.sbc,
                bpc = detail.bpc,
                bbc = detail.bbc,
                ft = detail.ft,
                bpn = detail.bpn,
                scln = detail.scln,
                scc = detail.scc,
                crn = detail.crn
            };
            //if i use delete by id here , it deletes the row of table rapidly without show any dialog box
            return View(viewmodel);

        }

        return RedirectToAction("CRUDInvoiceDetail");
    }
    /// <summary>
    /// i can't delete model from below delete method because it became the same above
    /// and make error 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> DeleteInvoiceDetail(Guid id, DeleteInvoiceDetailViewModel model)
    {

        var data = await _repository.FindByIdAsync(id);
        // Checking if any such record exist
        if (data != null)
        {
            await _repository.DeleteByIdAsync(id);
            return RedirectToAction("CRUDInvoiceDetail");
        }
        else
            return RedirectToAction("CRUDInvoiceDetail");
    }

}

