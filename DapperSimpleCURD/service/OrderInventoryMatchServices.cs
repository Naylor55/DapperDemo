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

namespace DapperDemo.service
{
    public interface OrderInventoryMatchServices
    {
        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        List<OrderInventoryMatch> FindOrderInventoryMatch();

        IEnumerable<OrderInventoryMatch> FindOrderInventoryMatchWhere(string str);

        /// <summary>
        /// 根据where条件获取预占库存，参数化方式。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<OrderInventoryMatch> FindOrderInventoryMatchWhere(string str, object obj);


        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrderInventoryMatch GetOrderInventoryMatchById(string id);

        int UpdateOrderInventoryMatch(OrderInventoryMatch obj);

        int InsertOrderInventoryMatch(OrderInventoryMatch obj);

        int DeleteOrderInventoryMatch(OrderInventoryMatch obj);
    }
}
