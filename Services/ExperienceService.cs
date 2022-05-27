using PortfolioSiteAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PortfolioSiteAPI.Services
{
    public class ExperienceService
    {
        private readonly IMongoCollection<Experience> _collection;

        public ExperienceService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = db.GetCollection<Experience>(databaseSettings.Value.ExperienceCollectionName);
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            var result = await _collection.Find(e => true).ToListAsync();
            return result;
        }

        public async Task<Experience?> GetOneAsync(string id)
        {
            var result = await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        //these will be used once authentication is added to controllers
        public async void CreateAsync(Experience newExperience)
        {
            await _collection.InsertOneAsync(newExperience);
        }

        public async void UpdateAsync(Experience updatedExperience)
        {
            await _collection.ReplaceOneAsync(e => e.Id == updatedExperience.Id, updatedExperience);
        }

        public async void DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
