namespace miniproj.Application.Commands
{
    using MediatR;
    using System;
    using System.Threading.Tasks;
    using miniproj.Domain.Entities;
    using miniproj.Domain.ValueObjects;
    using miniproj.Application.Interfaces;
    using miniproj.Domain.Services;
    using System.Threading;
    public class OrderCommand : IRequest
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Guid UserId { get; }
        public decimal Amount { get; }
        public string Currency { get; }

        public OrderCommand(Guid userId, decimal amount, string currency)
        {
            UserId = userId;
            Amount = amount;
            Currency = currency;
        }
    }
}