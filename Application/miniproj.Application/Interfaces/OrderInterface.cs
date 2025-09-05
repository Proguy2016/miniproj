using miniproj.Domain.Entities;
namespace miniproj.Application.Interfaces;
using System;
using System.Threading.Tasks;   
public interface IOrderRepository
{
    Task SaveAsync(Order order);
    Task UpdateAsync(Order order);
    Task<Order> GetByIdAsync(Guid id);
}

