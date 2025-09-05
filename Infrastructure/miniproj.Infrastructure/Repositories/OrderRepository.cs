namespace miniproj.Infrastructure.Repositories
{
    using System;
    using System.Threading.Tasks;   
    using MongoDB.Driver;

    using miniproj.Domain.Entities;
    using miniproj.Application.Interfaces; 


    public class MongoOrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public MongoOrderRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Order>("Orders");
        }

        public async Task SaveAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }
        public async Task UpdateAsync(Order order)
        {
            await _collection.ReplaceOneAsync(r => r.Id == order.Id, order);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}