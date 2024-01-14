using ManagingSalesOrderData.Shared.Dtos;

namespace ManagingSalesOrderData.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);

        Task<List<OrderDto>> GetOrdersAsync();

        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);

        Task<OrderDto> UpdateOrderAsync(OrderDto orderDto);

        Task DeleteOrderByIdAsync(int id);
    }
}
