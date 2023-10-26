using AccountingSubsystem.Domain.AggregatesModel;
using AccountingSubsystem.Domain.AggregatesModel.InvoiceHeaders;
using AccountingSubsystemIdentity.Models.InvoiceDetail;
using AccountingSubsystemIdentity.Models.InvoiceHeader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSubsystemIdentity.Controllers;

public class InvoiceHeaderController : Controller
{
    private readonly IInvoiceHeaderRepository _repository;
    public InvoiceHeaderController(IInvoiceHeaderRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> CRUDInvoiceHeader(int page=1)
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
    public async Task<IActionResult> CRUDInvoiceHeader(string search)
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
    public IActionResult CreateInvoiceHeader()
    {
        return View();
    }

    [HttpPost/*("Create")*/]
    public async Task<IActionResult> CreateInvoiceHeader(InvoiceHeaderViewModel invoice)
    {
        var header = new InvoiceHeaderDto()
        {
            From=invoice.From,
            To=invoice.To,
            Price=invoice.Price,
            Subject=invoice.Subject,
            IssueDate=invoice.IssueDate
        };
        await _repository.AddAsync(header);
        return RedirectToAction("CRUDInvoiceHeader");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateInvoiceHeader(Guid id)
    {
        var detail = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (detail is not null)
        {
            var viewmodel = new UpdateInvoiceHeaderViewModel()
            {
                // Id = compny.Id,
               From= detail.From,
               To=detail.To,
               Price=detail.Price,
               Subject=detail.Subject,
               IssueDate=detail.IssueDate
            };
            //   await _repository.UpdateByIdAsync(id);
            return View(viewmodel);
        }
        return RedirectToAction("CRUDInvoiceHeader");
    }

    // To specify that this will be
    // invoked when post method is called
    [HttpPost]
    public async Task<IActionResult> UpdateInvoiceHeader(/*Guid id,*/InvoiceHeaderDto model)
    {
        // Checking if any such record exist
        if (model != null)
        {

            await _repository.UpdateAsync(model);

            // It will redirect to
            // the Read method
            return RedirectToAction("CRUDInvoiceHeader");
        }
        else
            return RedirectToAction("CRUDInvoiceHeader");
    }
    [HttpGet]
    public async Task<IActionResult> DeleteInvoiceHeader(Guid id)
    {
        // var companyGuidid = Guid.Parse(companyid);
        var detail = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (detail is not null)
        {
            var viewmodel = new DeleteInvoiceHeaderViewModel()
            {
                // Id = compny.Id,
                From= detail.From,
                To=detail.To,
                Price=detail.Price,
                Subject=detail.Subject,
                IssueDate=detail.IssueDate
            };
            //if i use delete by id here , it deletes the row of table rapidly without show any dialog box
            return View(viewmodel);

        }

        return RedirectToAction("CRUDInvoiceHeader");
    }
    /// <summary>
    /// i can't delete model from below delete method because it became the same above
    /// and make error 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> DeleteInvoiceHeader(Guid id, DeleteInvoiceDetailViewModel model)
    {

        var data = await _repository.FindByIdAsync(id);
        // Checking if any such record exist
        if (data != null)
        {
            await _repository.DeleteByIdAsync(id);
            return RedirectToAction("CRUDInvoiceHeader");
        }
        else
            return RedirectToAction("CRUDInvoiceHeader");
    }

}
