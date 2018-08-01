using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.persistence
{
    public class PersistenceBase
    {
        protected readonly string connString = "Data Source = 192.168.0.138; Initial Catalog = LeadingDebug; Persist Security Info=True;User ID = sa; Password=XS12345^;  Min Pool Size=10;Max Pool Size=50;Connection Timeout = 15; Application Name = Leading.ERP";
    }
}
