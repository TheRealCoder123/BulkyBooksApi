using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.OrderDTOs;
using BulkyBookAPI.Domain.Entities;
using BulkyBookAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly BulkyDbContext _dbContext;

        public OrderRepository(BulkyDbContext bulkyDbContext)
        {
            _dbContext = bulkyDbContext;
        }


        public async Task<bool> AddOrderAsync(AddOrderDTO addOrderDTO)
        {

            var OrderId = Guid.NewGuid();

            var orderCreditCard = await _dbContext.CreditCard.Include(x => x.User)
                .FirstOrDefaultAsync(x => x.CardId == addOrderDTO.CreditCardId);

            var orderUser = await _dbContext.User
                .FirstOrDefaultAsync(x => x.UserId == addOrderDTO.UserID);

            var order = new Order
            {

                OrderId = OrderId,
                TotalPrice = addOrderDTO.TotalPrice,
                Date = DateTime.UtcNow,
                ShippingStatus = addOrderDTO.ShippingStatus,
                PaymentStatus = addOrderDTO.PaymentStatus,
                OrderItemsQuantity = addOrderDTO.OrderItemsQuantity,
                Address = addOrderDTO.Address,
                CreditCard = orderCreditCard,
                User = orderUser,
                Books = null
            };

            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();


            var orderedBooks = addOrderDTO.BookIds.ToList().Select(BookId => {

                var orderedBook = new OrderedBooks
                {
                    OrderedBookId = Guid.NewGuid(),
                    BookId = BookId,
                    OrderId = order.OrderId,
                };

                return orderedBook;
            
            }).ToList();

            await _dbContext.AddRangeAsync(orderedBooks);
            await _dbContext.SaveChangesAsync();


            var isAdded = _dbContext.Order.Contains(order);

            if (isAdded) {
                return true;
            }
            return false;
        }

        public Task<IEnumerable<OrderDTO>> FilterOrdersBy(string filterBy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
