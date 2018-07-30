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
    public class InventoryOperationLogServiceslmpl : InventoryOperationLogServices
    {
        private static readonly InventoryOperationLogRepository repository = new InventoryOperationLogRepositorylmpl();
        public List<InventoryOperationLog> FindInventoryItem()
        {
            return repository.FindInventoryItem();
        }

        public List<InventoryOperationLog> FindInventoryItemWhere(string str)
        {
            return repository.FindInventoryItemWhere(str);
        }

        public List<InventoryOperationLog> FindInventoryItemWhere(string str, object obj)
        {
            return repository.FindInventoryItemWhere(str, obj);
        }

        public InventoryOperationLog GetInventoryItemById(string id)
        {
            return repository.GetInventoryOperationLogById(id);
        }

        public int UpdateInventoryItem(InventoryOperationLog obj)
        {
            return repository.UpdateInventoryItem(obj);
        }

        public int InsertInventoryItem(InventoryOperationLog obj)
        {
            return repository.InsertInventoryItem(obj);
        }

        public int DeleteInventoryItem(InventoryOperationLog obj)
        {
            return repository.DeleteInventoryItem(obj);
        }
    }
}
