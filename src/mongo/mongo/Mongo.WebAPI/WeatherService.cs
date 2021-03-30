using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo.WebAPI
{
    public class WeatherService
    {
        private readonly IMongoCollection<WeatherForecast> _weathers;

        public WeatherService(IWeatherDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _weathers = database.GetCollection<WeatherForecast>(settings.WeathersCollectionName);
        }

        public List<WeatherForecast> Get() =>
            _weathers.Find(weather => true).ToList();

        public WeatherForecast Get(string id) =>
            _weathers.Find<WeatherForecast>(weather => weather.Id == id).FirstOrDefault();


        public List<WeatherForecast> GetTemperaturesGreaterThan(int temp) =>
            _weathers.Find<WeatherForecast>(weather => weather.TemperatureC > temp).ToList();

        public WeatherForecast Create(WeatherForecast weather)
        {
            _weathers.InsertOne(weather);
            return weather;
        }

        public void Update(string id, WeatherForecast weatherIn) =>
            _weathers.ReplaceOne(weather => weather.Id == id, weatherIn);

        public void Remove(WeatherForecast weatherIn) =>
            _weathers.DeleteOne(weather => weather.Id == weatherIn.Id);

        public void Remove(string id) =>
            _weathers.DeleteOne(weather => weather.Id == id);
    }
}
