using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace WebApplication8.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<Student> name = new List<Student>();
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
        public List<Student> Get()
        {
            string connectionstring = "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con = new SqlConnection(connectionstring);
            string hello = "select * from [dbo].[Table_1] order by name";
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();
            var result = new List<Student>();
            while (reader.Read())
            {
                Student st = new Student()
                {
                    roll = reader.GetInt32(0),
                    age = reader.GetInt32(1),
                    name = reader.GetString(2),
                    marks = reader.GetString(3)
                };
                result.Add(st);
            }
            return result;
            }
        [HttpGet]
        [Route("name")]
        public List<Student> Gethello([FromBody]object helo)
        {
            string connectionstring= "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con=new SqlConnection(connectionstring);
            string hello;
            string gh;
            string hel=helo.ToString();
            string[] h=hel.Split("\r");
            string g = h[1];
            string[] f = g.Split("\"");
            string t = f[1];
            if (t == "name")
                gh = f[3];
            else
            {
                gh = f[2];
                string[] fg = gh.Split(":");
                string[] jk = fg[1].Split(",");
                gh = jk[0];
            }
            if (t == "name" || t == "marks")
                hello = "Select * from Table_1 where " + t + " like " + "\'" + gh + "%\'";
            else
                hello = "Select * from Table_1 where " + t + "=" + " " + gh;
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();


            var result = new List<Student>();
            while (reader.Read())
            {
                Student st = new Student()
                {
                    roll = reader.GetInt32(0),
                    age = reader.GetInt32(1),
                    name = reader.GetString(2),
                    marks = reader.GetString(3)
                };
                result.Add(st);
            }
            return result;
        }
        [HttpGet]
        [Route("paging")]
        public List<Student> get_paging(int pageno,int page_size)
        {
            string connectionstring = "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con = new SqlConnection(connectionstring);
            string hello = "Select * from Table_1 order by roll offset " + (page_size * pageno) + "Rows fetch next " + page_size + "rows only";
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();
            while (reader.Read())
            {
                Student sr = new Student { roll = reader.GetInt32(0), age = reader.GetInt32(1), name = reader.GetString(2), marks = reader.GetString(3) };
                name.Add(sr);
            }
            return name;
        }
        [HttpPost]
        public void post([FromBody]Student st)
        {
            string connectionstring = "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con = new SqlConnection(connectionstring);
            string hello = "INSERT INTO Table_1 (roll,age,name,marks) VALUES("+st.roll+","+st.age+",'"+st.name+"','"+st.marks +"')";
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();
                     
        }
        [HttpDelete]
        public void delete(int roll)
        {
            string connectionstring = "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con = new SqlConnection(connectionstring);
            string hello = "DELETE FROM Table_1 WHERE roll="+roll+"";
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();
        }
        [HttpPut]
        public List<Student> put([FromBody]Student sd)
        {
            string connectionstring = "Server=LAPTOP-R0L029EH;Database=hello;Uid=vishwa; password=vishwa;";
            SqlConnection con = new SqlConnection(connectionstring);
            string hello = "UPDATE Table_1 SET roll="+sd.roll+",age="+sd.age+",name='"+sd.name+"',marks='"+sd.marks+"' WHERE roll="+sd.roll;
            SqlCommand sg = new SqlCommand(hello, con);
            con.Open();
            SqlDataReader reader = sg.ExecuteReader();
            name = Get();
            return name;
        }
       
    }
}
