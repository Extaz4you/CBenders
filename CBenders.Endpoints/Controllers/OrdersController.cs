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
        private ILogger<OrdersController> logger;

        public OrdersController(OrderService orderService, ILogger<OrdersController> log)
        {
            service = orderService;
            logger = log;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            logger.Log(LogLevel.Information, "try get all");
            return await service.GetAll();
        }
    }
}
