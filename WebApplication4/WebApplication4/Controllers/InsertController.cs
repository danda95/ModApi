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
    [Route("api/Insert")]
    public class InsertController : Controller
    {
        [HttpPost]
        public void Post([FromBody] dynamic data)
        {

            SQLConnect ConnectSettings = new SQLConnect();
            SqlConnection Connect = ConnectSettings.GetConnect();
            SqlCommand Command = new SqlCommand("insert into Details (Name,Species,NumberOfLegs) values('"+data.name+"','"+data.species+"','"+data.numberoflegs+"');", Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
            getDataFromServer g = new getDataFromServer();
            g.getFromServer();
        }
    }
}