using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DapperSimpleCURD.DAL
{
    public  class DbAction
    {
        IDbConnection  conn = new SqlConnection("Data Source = 192.168.0.138; Initial Catalog = Leading; Persist Security Info=True;User ID = sa; Password=XS12345^;  Min Pool Size=10;Max Pool Size=50;Connection Timeout = 15; Application Name = Leading.ERP");

        public  object GetList()
        {
            using (conn)
            {
                return conn.Query("select top 100 * from goods");
            }
        }

    }
}
