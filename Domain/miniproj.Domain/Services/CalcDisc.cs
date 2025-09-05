namespace miniproj.Domain.Services
{
    using miniproj.Domain.Entities;
    using miniproj.Domain.ValueObjects;
    using System.Threading.Tasks;

    public class CalculateDiscountForFirstOrder
    {
        public CalculateDiscountForFirstOrder()
        {

        }
        public Money ApplyDiscount(User user, Order order)
        {
            if (user.OrderCount == 0)
            {
                var discountAmount = order.TotalPrice.Amount * 0.1m;
                return order.TotalPrice.subtract(discountAmount);
            }
            return order.TotalPrice;
        }
    }
}