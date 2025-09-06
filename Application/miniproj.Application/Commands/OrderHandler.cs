namespace miniproj.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using miniproj.Application.Interfaces;
    using miniproj.Domain.Entities;
    using miniproj.Domain.ValueObjects;
    using miniproj.Domain.Services;
    public class OrderHandler : IRequestHandler<OrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        private readonly CalculateDiscountForFirstOrder _discountService;
        public OrderHandler(IOrderRepository orderRepository, IUserRepository userRepository, CalculateDiscountForFirstOrder discountService)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _discountService = discountService;
        }

        public async Task Handle(OrderCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
                throw new ArgumentException("User not found");

            Console.WriteLine($"User before order - Balance: {user.Balance}, OrderCount: {user.OrderCount}");

            if (user.Balance.Amount < command.Amount)
                throw new InvalidOperationException("Insufficient balance");
            var money = new Money(command.Amount, command.Currency);
            var order = new Order(command.Id, command.UserId, money);
            order.TotalPrice = _discountService.ApplyDiscount(user, order);
            
            Console.WriteLine($"Order total after discount: {order.TotalPrice}");
            
            if (user.Balance.Amount >= order.TotalPrice.Amount && user.Balance.Currency == order.TotalPrice.Currency)
            {
                user.Balance = user.Balance.subtract(order.TotalPrice.Amount);
                user.OrderCount += 1;
                Console.WriteLine($"User after order - Balance: {user.Balance}, OrderCount: {user.OrderCount}");
                Console.WriteLine("Order placed successfully");
            }
            else
            {
                throw new InvalidOperationException("Insufficient balance or currency mismatch");
            }

            await _orderRepository.SaveAsync(order);
            await _userRepository.UpdateAsync(user);
            
            Console.WriteLine("User updated in database");
        }
    }
}