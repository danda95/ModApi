using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Controllers;

namespace WebApplication4
{
    public class getDataFromServer
    {
        List<Animal> x = new List<Animal>();
        List<string> s = new List<string>();

        public void getFromServer()
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
           
        }
    }
}
