using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManagingSalesOrderData.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderyId([Required][FromRoute] int id)
        {
            return Ok(await _orderService.GetOrderByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto dto)
        {
            return Ok(await _orderService.CreateOrderAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto dto)
        {
            return Ok(await _orderService.UpdateOrderAsync(dto));
        }

        [HttpDelete("{id}", Name = "DeleteOrderById")]
        public async Task<IActionResult> DeleteOrderById([Required][FromRoute] int id)
        {
            await _orderService.DeleteOrderByIdAsync(id);

            return Ok();
        }
    }
}
