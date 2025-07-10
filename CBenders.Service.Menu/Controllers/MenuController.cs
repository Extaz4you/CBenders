using CBenders.Service.Menu.Models;
using CBenders.Service.Menu.Repository;
using CBenders.Service.Menu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;

namespace CBenders.Service.Menu.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    [HttpGet("/GetAll")]
    public async Task<ActionResult> GetAll()
    {
        return Ok();
    }
    [HttpGet("/Get{id:int}")]
    public async Task<ActionResult> Get([FromRoute] int id)
    {
        return Ok();
    }
    [HttpPut("/Update")]
    public async Task<ActionResult> Update([FromBody] MenuItems item)
    {
        return Ok();
    }
    [HttpDelete("/Delete{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        return Ok();
    }
    [HttpPost("/Create")]
    public async Task<ActionResult> Create([FromBody] MenuItems item)
    {
        return Ok();
    }
}
