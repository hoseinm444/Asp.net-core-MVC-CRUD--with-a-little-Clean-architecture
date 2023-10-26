using AccountingSubsystem.Domain.AggregatesModel.Invoice.InvoiceEntity;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSubsystem.Api.Controllers;
[Route("api/self-tsp/async/")]
[ApiController]
public class Async_Self_tsp_Controller : ControllerBase
{
    //private readonly ILogger _logger;
    //private readonly ILogger<InvoiceEncryption> ;
    //public Async_Self_tsp_Controller(/*ILogger logger*/)
    //{
    //   // _logger = logger;
    //}

    // POST api/<Async_Self_tsp_Requests>
    //[HttpPost("normal-enqueue/")/*,BasicAuthorization*/]
    //public IActionResult Post(/*[FromForm] InvoiceDto invoice*/)
    //{
    //    var invoice = new InvoiceDto();
    //    if (invoice is not null)
    //    {
    //        //  var InvoiceEncrypt = new InvoiceEncryption(/*_logger*/).InvoiceSecurity(invoice);
    //        ////var InvoiceEncryptAsymetric = new InvoiceEncryption(/*_logger*/).SignWithPublicKey(invoice);
    //        //var req = new Request()
    //        //{
    //        //    body = new EachBody()
    //        //};
    //        //return Ok(InvoiceEncrypt);
    //    }
    //    else
    //        return BadRequest();
    //}

    //[HttpPost("fast-enqueue/")]
    //public async Task<IActionResult> Post_Fast([FromBody] string value)
    //{
    //    var invoice = new InvoiceDto();
    //    if (invoice is not null)
    //    {
    //        var InvoiceEncrypt =   new InvoiceEncryption(/*_logger*/).InvoiceSecurity(invoice);

    //        var req = new Request()
    //        {
    //            body = new EachBody()
    //        };
    //        return Ok(InvoiceEncrypt);
    //    }
    //    else
    //        return BadRequest();
    //}

}

