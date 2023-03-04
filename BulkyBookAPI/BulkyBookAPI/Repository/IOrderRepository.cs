using BulkyBookAPI.Domain.DTOs.OrderDTOs;

namespace BulkyBookAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrderAsync(AddOrderDTO addOrderDTO);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(Guid userId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderDTO>> FilterOrdersBy(string filterBy);
        Task<bool> UpdateOrderAsync(OrderDTO orderDTO);

    
    }
}
