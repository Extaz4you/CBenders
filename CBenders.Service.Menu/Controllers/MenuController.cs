using CBenders.Service.Menu.Models;
using CBenders.Service.Menu.Repository;
using CBenders.Service.Menu.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;

namespace CBenders.Service.Menu.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MenuController : ControllerBase
{
    private IMenuRepositories menu;
    private IConvertModel convert;
    public MenuController(IMenuRepositories menuRepositories, IConvertModel convertModel)
    {
        menu = menuRepositories;
        convert = convertModel;
    }

    [HttpGet("All")]
    public async Task<ActionResult> GetMenuItems()
    {
        var result = await menu.GetAll();
        if (result.Any()) return Ok(convert.GetList(result));
        else return NoContent();
    }
    [HttpGet("Get/{id:int}")]
    public async Task<ActionResult> MenuItem([FromRoute] int id)
    {
        var menuItem = await menu.Get(id);
        if (menuItem != null) return Ok(convert.GetSingle(menuItem));
        else return NoContent();
    }
    [HttpPut("Update")]
    public async Task<ActionResult> Update([FromBody] MenuItems item)
    {
        var menuItem = await menu.Update(item);
        if (menuItem != null) return Ok(convert.GetSingle(menuItem));
        else return NoContent();
    }
    [HttpDelete("Delete/{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if(await menu.Delete(id)) return Ok();
        else return NoContent();
    }
    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] MenuItems item)
    {
        var newItem = await menu.Create(item);
        if(newItem.Id == 0) return BadRequest();
        else return Ok(newItem);
    }
}
