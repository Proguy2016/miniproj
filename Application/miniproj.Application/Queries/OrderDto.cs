namespace miniproj.Application.Queries
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public miniproj.Domain.ValueObjects.Money TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}