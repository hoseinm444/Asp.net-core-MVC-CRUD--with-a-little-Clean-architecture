using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSubsystem.Api.Controllers;
[Route("api/tsp/async/")]
[ApiController]
public class Async_tsp_Requests : ControllerBase
{

    // POST api/<Async_tsp_Requests>
    [HttpPost("normal-enqueue")]
    public void Post([FromBody] string value)
    {
    }

    [HttpPost("fast-enqueue/")]
    public void Post_Fast([FromBody] string value)
    {
    }
}

