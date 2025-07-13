using CBenders.Endpoints.Models;
using CBenders.Endpoints.Services;
using CBenders.Endpoints.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IApiService<MenuItem, int> service;

        public MenuController(MenuService menuService)
        {
            service = menuService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> AllMenu()
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
        public async Task<ActionResult> Update([FromBody] MenuItem menuItem)
        {
            return Ok(await service.UpdateAsync(menuItem));
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] MenuItem menuItem)
        {
            return Ok(await service.CreateAsync(menuItem));
        }
    }
}
