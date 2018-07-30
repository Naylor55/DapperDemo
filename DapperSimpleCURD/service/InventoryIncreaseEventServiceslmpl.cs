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
    public class InventoryIncreaseEventServiceslmpl : IInventoryIncreaseEventServices
    {
        private static readonly IInventoryIncreaseEventRepository repository = new InventoryIncreaseEventRepositorylmpl();
        public IEnumerable<InventoryIncreaseEvent> FindInventoryIncreaseEvent()
        {
            return repository.FindInventoryIncreaseEvent();
        }

        public List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str)
        {
            return repository.FindInventoryIncreaseEventWhere(str);
        }

        public List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str, object obj)
        {
            return repository.FindInventoryIncreaseEventWhere(str, obj);
        }


        public InventoryIncreaseEvent GetInventoryIncreaseEventById(string id)
        {
            return repository.GetInventoryIncreaseEventById(id);
        }

        public int UpdateInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            return repository.UpdateInventoryIncreaseEvent(obj);
        }

        public int InsertInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            return repository.InsertInventoryIncreaseEvent(obj);
        }

        public int DeleteInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            return repository.DeleteInventoryIncreaseEvent(obj);
        }

        public int DeleteInventoryIncreaseEvent()
        {
            return repository.DeleteInventoryIncreaseEvent();
        }


    }
}
