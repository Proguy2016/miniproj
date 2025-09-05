using miniproj.Domain.Entities;
using MediatR;
namespace miniproj.Application.Queries
{
    public class OrderQuery : IRequest<OrderDto>
    {
        public Guid OrderId { get; }

        public OrderQuery(Guid orderId)
        {
            OrderId = orderId;

        }
    }
}