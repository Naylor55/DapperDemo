/********************************************************************************
** Company： 领先未来科技集团有限公司
** Auth：    陈明亮
** Email:    Cnaylor@163.com
** Date：    2018/7/3 13:42:44
** ClassName:InventoryItem
** Namespace:LeadingClass
** Desc：    
*********************************************************************************/


using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperDemo.persistence;

namespace DapperDemo.service
{
    public class OrderInventoryMatchServiceslmpl : OrderInventoryMatchServices
    {
        private static readonly IOrderInventoryMatchRepository repository = new OrderInventoryMatchRepositorylmpl();
        public List<OrderInventoryMatch> FindOrderInventoryMatch()
        {
            return repository.FindOrderInventoryMatch();
        }

        public IEnumerable<OrderInventoryMatch> FindOrderInventoryMatchWhere(string str)
        {
            return repository.FindOrderInventoryMatchWhere(str);
        }

        public List<OrderInventoryMatch> FindOrderInventoryMatchWhere(string str, object obj)
        {
            return repository.FindOrderInventoryMatchWhere(str, obj);
        }


        public OrderInventoryMatch GetOrderInventoryMatchById(string id)
        {
            return repository.GetOrderInventoryMatchById(id);
        }

        public int UpdateOrderInventoryMatch(OrderInventoryMatch obj)
        {
            return repository.UpdateOrderInventoryMatch(obj);
        }

        public int InsertOrderInventoryMatch(OrderInventoryMatch obj)
        {
            return repository.InsertOrderInventoryMatch(obj);
        }

        public int DeleteOrderInventoryMatch(OrderInventoryMatch obj)
        {
            return repository.DeleteOrderInventoryMatch(obj);
        }
    }
}
