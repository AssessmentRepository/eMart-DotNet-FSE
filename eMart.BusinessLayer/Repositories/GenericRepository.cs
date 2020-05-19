using eMart.BusinessLayer.Interfaces;
using eMart.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMart.BusinessLayer.Repositories
{
    public class GenericRepository<T> : IGenericeRepository<T> where T : class
    {

        public readonly IMongoDBContext _mongoContext;
        public IMongoCollection<T> _dbCollection;

        public GenericRepository(IMongoDBContext context) 
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAll()
        {
            // return await _context.ToListAsync();
            var all = await _dbCollection.FindAsync(Builders<T>.Filter.Empty, null);
            return await all.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            //var objectId = new ObjectId(id);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

    }
}