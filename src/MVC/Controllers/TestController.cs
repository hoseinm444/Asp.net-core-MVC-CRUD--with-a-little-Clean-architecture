using AccountingSubsystem.Domain.AggregatesModel.Company;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSubsystemIdentity.Controllers;

public class TestController : Controller
{
    private readonly ICompanyRepository _repository;
    public TestController(ICompanyRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        //var companies = await _repository.FindAllAsync();
        //return View(companies);
        return View();
    }

    public JsonResult getAll()
    {

        var companies = _repository.FindAllAsync();

        return Json(new { data = companies });
    }

}
