using CBenders.Service.Orders.Model;
using CBenders.Service.Orders.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Service.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService service;

        public OrderController(OrderService orderService)
        {
            service = orderService;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<OrderEntity>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("Get/{id:int}")]
        public async Task<OrderEntity> GetById(int id)
        {
            if (id > 0) return await service.GetById(id);
            else return new OrderEntity();
        }

        [HttpPost("Create")]
        public async Task<OrderEntity> Create(OrderEntity order)
        {
            if(await service.Create(order)) return order;
            return new OrderEntity();
        }

        [HttpPut("Update")]
        public async Task<OrderEntity> Update(OrderEntity order)
        {
            if(await service.Update(order)) return order;
            return new OrderEntity();
        }

    }
}
