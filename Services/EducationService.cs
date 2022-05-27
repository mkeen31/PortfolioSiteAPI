﻿using PortfolioSiteAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PortfolioSiteAPI.Services
{
    public class EducationService
    {
        private readonly IMongoCollection<Education> _collection;

        public EducationService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _collection = db.GetCollection<Education>(databaseSettings.Value.EducationCollectionName);
        }

        public async Task<List<Education>> GetAllAsync()
        {
            var result = await _collection.Find(e => true).ToListAsync();
            return result;
        }

        public async Task<Education?> GetOneAsync(string id)
        {
            var result = await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        //these will be used once authentication is added to controllers
        public async void CreateAsync(Education newEducation)
        {
            await _collection.InsertOneAsync(newEducation); 
        }

        public async void UpdateAsync(Education updatedEducation)
        {
            await _collection.ReplaceOneAsync(e => e.Id == updatedEducation.Id, updatedEducation);
        }

        public async void DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
