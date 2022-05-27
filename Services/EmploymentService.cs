using PortfolioSiteAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PortfolioSiteAPI.Services
{
    public class EmploymentService
    {
        private readonly IMongoCollection<Employment> _collection;

        public EmploymentService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = db.GetCollection<Employment>(databaseSettings.Value.EmploymentCollectionName);
        }

        public async Task<List<Employment>> GetAllAsync()
        {
            var result = await _collection.Find(e => true).ToListAsync();
            return result;
        }

        public async Task<Employment?> GetOneAsync(string id)
        {
            var result = await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        //these will be used once authentication is added to controllers
        public async void CreateAsync(Employment newEmployment)
        {
            await _collection.InsertOneAsync(newEmployment);
        }

        public async void UpdateAsync(Employment updatedEmployment)
        {
            await _collection.ReplaceOneAsync(e => e.Id == updatedEmployment.Id, updatedEmployment);
        }

        public async void DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
