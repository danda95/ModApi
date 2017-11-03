using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
    [Produces("application/json")]
    [Route("api/Update")]
    public class UpdateController : Controller
    {
        
        [HttpPost]
        public void Post([FromBody] dynamic data)
        {
            SQLConnect ConnectSettings = new SQLConnect();
            SqlConnection Connect = ConnectSettings.GetConnect();
            SqlCommand Command = new SqlCommand("update Details set Name='"+data.name+"',Species='"+data.species+"',NumberOfLegs='"+data.numberoflegs+"' where Id='" + data.id + "';", Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
            getDataFromServer g = new getDataFromServer();
            g.getFromServer();

        }
    }
}