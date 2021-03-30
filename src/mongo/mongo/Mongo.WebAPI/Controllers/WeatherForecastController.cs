using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherService _ws;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherService ws)
        {
            _logger = logger;
            _ws = ws;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_ws.Get());
        }

        [HttpGet]
        [Route(@"{id}")]
        public ActionResult Get([FromRoute] string id)
        {
            return Ok(_ws.Get(id));
        }

        [HttpGet()]
        [Route(@"Temperature/{temperature}")]
        public ActionResult Get([FromRoute] int temperature)
        {
            return Ok(_ws.GetTemperaturesGreaterThan(temperature));
        }

        [HttpPost]
        public ActionResult Post(WeatherForecast forecast)
        {
            _ws.Create(forecast);
            return Ok(forecast);
        }


        [HttpPut]
        public ActionResult Put(WeatherForecast forecast)
        {
            _ws.Update(forecast.Id, forecast);
            return Ok(forecast);
        }


        [HttpDelete]
        public ActionResult Delete(string id) 
        { 
            _ws.Remove(id);
            return Ok();
        }
    }
}
