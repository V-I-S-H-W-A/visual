using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static List<Student> name = new List<Student>();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            int length = name.Count;
            for(int i=0;i<length;i+=2)
            {
                Student st;
                st = name[i];
                name[i] = name[i + 1];
                name[i + 1] = st;
                int temp=name[i].roll;
                name[i].roll = name[i + 1].roll;
                name[i + 1].roll = temp;
            }
            return Ok(name);
        }
        [HttpPost]
        public IActionResult Put([FromBody]Student obj)
        {
            name.Add(obj);
            return Ok(name);
        }
    }
}
