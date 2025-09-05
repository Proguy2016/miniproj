using miniproj.Domain.Entities;
namespace miniproj.Application.Interfaces;
using System;
using System.Threading.Tasks;
public interface IUserRepository
{
    Task SaveAsync(User user);
    Task UpdateAsync(User user);
    Task<User> GetByIdAsync(Guid id);
}

