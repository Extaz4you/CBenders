using CBenders.Endpoints.Models;
using CBenders.Endpoints.Services;
using CBenders.Endpoints.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Endpoints.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TablesController : ControllerBase
{
    private IApiService<Tables, int> service;

    public TablesController(TableService tablesService)
    {
        service = tablesService;
    }

    [HttpGet("All")]
    public async Task<ActionResult> AllTables()
    {
        return Ok(await service.GetAllAsync());
    }
    [HttpGet("Get")]
    public async Task<ActionResult> GetById(int id)
    {
        return Ok(await service.GetByIdAsync(id));
    }
    [HttpDelete("Delete/{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await service.DeleteAsync(id));
    }
    [HttpPut("Update")]
    public async Task<ActionResult> Update([FromBody] Tables table)
    {
        return Ok(await service.UpdateAsync(table));
    }
    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] Tables table)
    {
        return Ok(await service.CreateAsync(table));
    }
}
