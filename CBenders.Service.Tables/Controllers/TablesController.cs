﻿using CBenders.Service.Tables.Model;
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
        [HttpGet]
        public async Task<IEnumerable<TablesModel>> All()
        {
            return await service.All();
        }
        [HttpGet("{id:int}")]
        public async Task<TablesModel> Get(int id)
        {
            return await service.GetById(id);
        }
        [HttpDelete("{id:int}")]
        public async Task<bool> Delete(int id)
        {
            if (service.Delete(id).IsFaulted == false)
            {
                service.SaveAsync();
                return true;
            }
            else return false;
        }
        [HttpPut]
        public async Task<TablesModel> Update(TablesModel model)
        {
            await service.Update(model);
            await service.SaveAsync();
            return model;
        }
        [HttpPost]
        public async Task<TablesModel> Create(TablesModel model)
        {
            await service.Create(model);
            await service.SaveAsync();
            return model;
        }
    }
}
