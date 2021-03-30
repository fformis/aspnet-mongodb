using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Mongo.WebAPI
{
    public class WeatherDatabaseSettings : IWeatherDatabaseSettings
    {
        public string WeathersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWeatherDatabaseSettings
    {
        string WeathersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class WeatherForecast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
