using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    public class Class: ControllerBase
    {
        int a = 54;
        int b = 89;
        [HttpGet]
        public int Get()
        {
            int x = a + b;
            return x;
        }
        [HttpPut]
        public int Put()
        {
            int x = a * b;
            return x;
        }
        [HttpPost]
        public int Post()
        {
            int x = b / a;
            return x;
        }
        [HttpDelete]
        public int Delete()
        {
            int x = a - b;
            return x;
        }
    }
}
