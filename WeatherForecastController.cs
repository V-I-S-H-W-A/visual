using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;
namespace WebApplication5.Controllers
{

    [ApiController]
    [Route("[controller]")]
    
    public class WeatherForecastController : ControllerBase
    {
        static List<Student> name = new List<Student>();
        Student sg = new Student() { roll = 44, age = 56, name3 = "jilk" };
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
            
        }

        [HttpGet]
        public string Get()
        {

            String json = JsonConvert.SerializeObject(name);
            return json;/*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            */
        }
        [HttpPost]
        public void Post(int age, int roll, string namer)
        {
            Student sg = new Student()
            {
                roll = 43,
                age = 43,
                name3 = "hello"
            };
            Student gf = new Student()
            {
                roll = 56,
                age = 67,
                name3 = "vishwa"
            };
            name.Add(sg);
            name.Add(gf);
            Student gh = new Student() { age = age, roll = roll, name3 = namer };
            name.Add(gh);
        }
        [HttpPut]
        public void putAll(int roll,int age,string name3)
        {
            var item = name.SingleOrDefault(x => x.roll == roll);
            name.Remove(item);
            item.age = age;
            item.name3 = name3;
            name.Add(item);
        }
        [HttpDelete]
        public void Delete(int roll,int age,string name3)
        {

           var item = name.SingleOrDefault(x => x.roll == roll);
           name.Remove(item);

        }
    }
}
