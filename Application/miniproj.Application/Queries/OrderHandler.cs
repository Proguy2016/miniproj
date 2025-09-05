
namespace miniproj.Application.Queries
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using miniproj.Application.Interfaces;
    using miniproj.Domain.Entities;
    
    

    public class OrderHandler : IRequestHandler<OrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        public OrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public async Task<OrderDto> Handle(OrderQuery command, CancellationToken cancellationToken)
        {
            var Order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (Order == null) return null;
            var orderDto = new OrderDto
            {
                Id = Order.Id,
                UserId = Order.UserId,
                TotalPrice = Order.TotalPrice,
                OrderDate = Order.OrderDate
            };

            return orderDto;
        }
    }
}