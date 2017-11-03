using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        List<Animal> x = new List<Animal>();
        List<string> s = new List<string>();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            SQLConnect ConnectSettings = new SQLConnect();
            SqlConnection Connect = ConnectSettings.GetConnect();
            SqlCommand Command = new SqlCommand("select * from Details;", Connect);
            Connect.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                x.Add(new Animal(int.Parse(Reader["Id"].ToString()), Reader["Name"].ToString(), Reader["Species"].ToString(), int.Parse(Reader["NumberOfLegs"].ToString())));
            }
            Connect.Close();
            string json = JsonConvert.SerializeObject(x.ToArray());
            s.Add(json);
            System.IO.File.WriteAllText("../WebApplication4/wwwroot/json/data.json", json);
            return s;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] dynamic data)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete([FromBody] dynamic data)
        {
            
        }
    }
}
