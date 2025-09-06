using miniproj.Domain.ValueObjects;
namespace miniproj.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set;}
        public Guid UserId { get; set;}
        public Money TotalPrice { get; set; }
        public DateTime OrderDate { get; set;}
        public Order(){}
        public Order(Guid orderId,Guid userId, Money totalPrice)
        {
            this.Id = orderId;
            this.UserId = userId;
            this.TotalPrice = totalPrice;
            this.OrderDate = DateTime.Now;
        }
           
    }
}