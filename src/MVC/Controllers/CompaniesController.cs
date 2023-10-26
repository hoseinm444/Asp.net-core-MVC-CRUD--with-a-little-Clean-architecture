using AccountingSubsystem.Domain.AggregatesModel;
using AccountingSubsystem.Domain.AggregatesModel.Company;
using AccountingSubsystem.Infra.Data.Sql.Repositories;
using AccountingSubsystemIdentity.Models.Company;
using JsonApiDotNetCore.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountingSubsystemIdentity.Controllers;

public class CompaniesController : Controller
{
    private readonly ICompanyRepository _repository;
    public CompaniesController(ICompanyRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> CRUDCompany(int page = 1)
    {
        var companies = await _repository.FindAllAsync();
        const int pageSize = 10;
        if (page < 1)
            page = 1;
        int rescCount = companies.Count();
        var pager = new PagedList(rescCount, page, pageSize);
        int recSkip = (page - 1) * pageSize;
        var data = companies.Skip(recSkip).Take(pager.PageSize).ToList();
        this.ViewBag.Pager = pager;
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> CRUDCompany(string search)
    {
        if (search is not null)
        {
            var companies = await _repository.FindByInputValueAsync(search);
            return View(companies);
        }
        else
        {
            var companies = await _repository.FindAllAsync();
            return View(companies);
        }
    }
    [HttpGet]
    public IActionResult CreateCompany()
    {
        return View();
    }
    [HttpPost/*("Create")*/]
    public async Task<IActionResult> CreateCompany(CompanyViewModel CreateReq)
    {
        var company = new CompanyDto()
        {
            CompanyName = CreateReq.CompanyName,
            CompanyCode = CreateReq.CompanyCode,
            EconomicCode = CreateReq.EconomicCode,
            CompanyAddress = CreateReq.CompanyAddress,
            CompanyPhoneNumber = CreateReq.CompanyPhoneNumber
        };

        await _repository.AddAsync(company);
        string message = "Created the record successfully";
        // To display the message on the screen
        // after the record is created successfully
        ViewBag.Message = message;
        // return RedirectToPage("CRUDCompany");
        return RedirectToAction("CRUDCompany");
    }

    // To fill data in the form
    // to enable easy editing
    //[Route("UpdateCompany/{id:Guid}")]
    [HttpGet]
    public async Task<IActionResult> UpdateCompany(Guid id)
    {
        var compny = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (compny is not null)
        {
            var viewmodel = new UpdateCompanyViewModel()
            {
                // Id = compny.Id,
                CompanyName = compny.CompanyName,
                CompanyCode = compny.CompanyCode,
                EconomicCode = compny.EconomicCode,
                CompanyAddress = compny.CompanyAddress,
                CompanyPhoneNumber = compny.CompanyPhoneNumber
            };
            //   await _repository.UpdateByIdAsync(id);
            return View(viewmodel);
        }
        return RedirectToAction("CRUDCompany");
    }

    // To specify that this will be
    // invoked when post method is called
    [HttpPost]
    public async Task<IActionResult> UpdateCompany(/*Guid id,*/CompanyDto model)
    {
        // Checking if any such record exist
        if (model != null)
        {

            await _repository.UpdateAsync(model);

            // It will redirect to
            // the Read method
            return RedirectToAction("CRUDCompany");
        }
        else
            return RedirectToAction("CRUDCompany");
    }
    [HttpGet]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        // var companyGuidid = Guid.Parse(companyid);
        var compny = await _repository.FindByIdAsync(id);
        //we should not pass our domain object we should convert it to update view model
        if (compny is not null)
        {
            var viewmodel = new DeleteCompanyViewModel()
            {
                // Id = compny.Id,
                CompanyName = compny.CompanyName,
                CompanyCode = compny.CompanyCode,
                EconomicCode = compny.EconomicCode,
                CompanyAddress = compny.CompanyAddress,
                CompanyPhoneNumber = compny.CompanyPhoneNumber
            };
            //if i use delete by id here , it deletes the row of table rapidly without show any dialog box
            return View(viewmodel);

        }

        return RedirectToAction("CRUDCompany");
    }
    /// <summary>
    /// i can't delete model from below delete method because it became the same above
    /// and make error 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> DeleteCompany(Guid id, DeleteCompanyViewModel model)
    {

        var data = await _repository.FindByIdAsync(id);
        // Checking if any such record exist
        if (data != null)
        {
            await _repository.DeleteByIdAsync(id);
            return RedirectToAction("CRUDCompany");
        }
        else
            return RedirectToAction("CRUDCompany");
    }

    //public JsonResult getAll()
    //{

    //    var companies = _repository.FindAllAsync();

    //    return Json(new { data = companies });
    //}


}
