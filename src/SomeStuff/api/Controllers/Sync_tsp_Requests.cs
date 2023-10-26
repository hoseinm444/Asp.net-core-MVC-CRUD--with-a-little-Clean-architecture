using AccountingSubsystem.BasicAthentication.Athentication.Basic.Attributes;
using AccountingSubsystem.Domain.AggregatesModel.ConfigurationTaxPayerEndpoint;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSubsystem.Api.Controllers;
[Route("/api/tsp/sync/")]
[ApiController]
public class Sync_tsp_Requests : ControllerBase
{
    // GET api/<Sync_tsp_Requests>/5
    [HttpPost("GET_TOKEN/"),BasicAuthorization]
    public JsonWebToken GET_TOKEN(string username)
    {
        var token = new JsonWebToken();
        return token;
    }

    [HttpGet("GET_FISCAL_INFORMATION/")]
    public FiscalInformation GET_FISCAL_INFORMATION()
    {
        var fiscal = new FiscalInformation();
        return fiscal;
    }

    [HttpGet("GET_SERVER_INFORMATION/")]
    public FiscalInformation GET_SERVER_INFORMATION()
    {
        var fiscal = new FiscalInformation();
        return fiscal;
    }


    [HttpGet("GET_ECONOMIC_CODE_INFORMATION/")]
    public FiscalInformation GET_ECONOMIC_CODE_INFORMATION()
    {
        var fiscal = new FiscalInformation();
        return fiscal;
    }

    // GET: api/<Sync_tsp_Requests>
    [HttpGet("GET_SERVICE_STUFF_LIST")]
    public IEnumerable<string> GET_SERVICE_STUFF_LIST()
    {
        return new string[] { "value1", "value2" };
    }


    [HttpGet("INQUIRY_BY_TIME_RANGE")]
    public IEnumerable<string> INQUIRY_BY_TIME_RANGE()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("INQUIRY_BY_TIME")]
    public IEnumerable<string> INQUIRY_BY_TIME()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("INQUIRY_BY_REFERENCE_NUMBER")]
    public IEnumerable<string> INQUIRY_BY_REFERENCE_NUMBER()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("INQUIRY_BY_UID")]
    public IEnumerable<string> INQUIRY_BY_UID()
    {
        return new string[] { "value1", "value2" };
    }

}

