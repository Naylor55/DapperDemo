
using Dapper;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int item = (int)Action.AddAssignedQtyAndReduceAvailableQty;
        }
    }
    public enum Action
    {
        AddAssignedQty = 0,
        ReduceAssignedQty = 1,
        AddAvailableQty = 2,
        ReduceAvailableQty = 3,
        ReduceAssignedQtyAndAddAvailableQty = 4,
        AddAssignedQtyAndReduceAvailableQty = 5
    }
}
