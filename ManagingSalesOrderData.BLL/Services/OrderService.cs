using ManagingSalesOrderData.Shared.Dtos;
using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.DAL.Entities;
using ManagingSalesOrderData.DAL.Interfaces;
using Mapster;

namespace ManagingSalesOrderData.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IValidator _validator;
        public OrderService(IOrderRepository orderRepository, IValidator validator)
        {
            _orderRepository = orderRepository;
            _validator = validator;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            return order.Adapt<OrderDto>();
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Adapt<List<OrderDto>>();
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            _validator.ValidateDto(orderDto, orderDto.Name, orderDto.State);

            var order = await _orderRepository.CreateAsync(orderDto.Adapt<Order>());

            return order.Adapt<OrderDto>();
        }

        public async Task<OrderDto> UpdateOrderAsync(OrderDto orderDto)
        {
            _validator.ValidateDto(orderDto);

            var order = await _orderRepository.UpdateAsync(orderDto.Adapt<Order>());

            return order.Adapt<OrderDto>();
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            await _orderRepository.DeleteByIdAsync(id);
        }
    }
}
