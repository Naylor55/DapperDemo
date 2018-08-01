
using Dapper;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    class Program
    {
        protected static readonly string connString = "Data Source = 192.168.0.138; Initial Catalog = LeadingDebug; Persist Security Info=True;User ID = sa; Password=XS12345^;  Min Pool Size=10;Max Pool Size=50;Connection Timeout = 15; Application Name = Leading.ERP";
        static IDbConnection conn = new SqlConnection(connString);
        static void Main(string[] args)
        {
            SysErrorLog e = new SysErrorLog()
            {
                ErrorMessage = "测试dapper对象插入",
                Memo = "55",
                RelationId = "5",
                TableName = "table",
                UpdateTime = DateTime.Now
            };
            int tip = (int)conn.Insert<SysErrorLog>(e);
        }
    }

}
