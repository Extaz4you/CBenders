using CBenders.Endpoints.Models;
using CBenders.Endpoints.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderService service;

        public OrdersController(OrderService orderService)
        {
            service = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await service.GetAll();
        }
    }
}
