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
        private IApiService<MenuDto, int> service;

        public MenuController(MenuService menuService)
        {
            service = menuService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> AllMenu()
        {
            return Ok(await service.GetAllAsync());
        }
    }
}
