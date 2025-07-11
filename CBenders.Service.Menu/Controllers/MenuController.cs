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
    private IMenuRepositories menu;
    private IConvertModel convert;
    private MenuResponse response;

    public MenuController(IMenuRepositories menuRepositories, IConvertModel convertModel)
    {
        menu = menuRepositories;
        convert = convertModel;
        response = new MenuResponse();
    }

    [HttpGet("/GetAll")]
    public async Task<ActionResult> GetAll()
    {
        response.Data = convert.GetList(await menu.GetAll());
        return Ok(response);
    }
    [HttpGet("/Get{id:int}")]
    public async Task<ActionResult> Get([FromRoute] int id)
    {
        var menuItem = await menu.Get(id);
        if (menuItem == null)
        {
            response.IsSuccess = false;
            response.StatusCode = System.Net.HttpStatusCode.NotFound;
        }
        else response.Data = convert.GetSingle(menuItem);
        
        return Ok(response);
    }
    [HttpPut("/Update")]
    public async Task<ActionResult> Update([FromBody] MenuItems item)
    {
        response.Data = convert.GetSingle(await menu.Update(item));
        response.StatusCode = System.Net.HttpStatusCode.OK;
        return Ok(response);
    }
    [HttpDelete("/Delete{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        bool isDeleted = await menu.Delete(id);
        response.IsSuccess = isDeleted ? true : false;
        response.StatusCode = System.Net.HttpStatusCode.NoContent;
        return Ok(response);
    }
    [HttpPost("/Create")]
    public async Task<ActionResult> Create([FromBody] MenuItems item)
    {
        response.Data = convert.GetSingle(await menu.Create(item));
        response.StatusCode = System.Net.HttpStatusCode.Created;
        return Ok(response);
    }
}
