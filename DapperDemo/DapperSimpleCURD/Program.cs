using System;

namespace DapperSimpleCURD
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.DbAction dbconn = new DAL.DbAction();
            var obj = dbconn.GetList();
        }
    }
}
