using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class SQLConnect
    {
        
        
        public SqlConnection GetConnect()
        {
            SqlConnection Connect = new SqlConnection("Data Source=DESKTOP-DLBV254\\SQLEXPRESS;Initial Catalog=Animals;Integrated Security=True");
            return Connect;
        }

    }
}
