namespace miniproj.Infrastructure.Repositories
{
using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using miniproj.Domain.Entities;
using miniproj.Application.Interfaces;



    public class MongoUserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public MongoUserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("Users");
        }

        public async Task SaveAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }
        public async Task UpdateAsync(User user)
        {
            await _collection.ReplaceOneAsync(r => r.Id == user.Id, user);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}