﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioSiteAPI.Models
{
    public class Experience
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Institution { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
