using CBenders.Service.Tables.Model;
using CBenders.Service.Tables.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Service.Tables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private TablesService service;
        public TablesController(TablesService tablesService)
        {
            service = tablesService;
        }
        [HttpGet("All")]
        public async Task<IEnumerable<TablesModel>> All()
        {
            return await service.All();
        }
        [HttpGet("Get/{id:int}")]
        public async Task<TablesModel> Get(int id)
        {
            return await service.GetById(id);
        }
        [HttpDelete("Delete/{id:int}")]
        public async Task<bool> Delete(int id)
        {
            if (service.Delete(id).IsFaulted == false)
            {
                service.SaveAsync();
                return true;
            }
            else return false;
        }
        [HttpPut("Update")]
        public async Task<TablesModel> Update(TablesModel model)
        {
            await service.Update(model);
            await service.SaveAsync();
            return model;
        }
        [HttpPost("Create")]
        public async Task<TablesModel> Create(TablesModel model)
        {
            await service.Create(model);
            await service.SaveAsync();
            return model;
        }
    }
}
