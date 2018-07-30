/********************************************************************************
** Company： 领先未来科技集团有限公司
** Auth：    陈明亮
** Email:    Cnaylor@163.com
** Date：    2018/7/3 13:42:44
** ClassName:InventoryItem
** Namespace:LeadingClass
** Desc：    
*********************************************************************************/

using Dapper;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DapperDemo.persistence
{
    public interface IInventoryIncreaseEventRepository
    {
        IDbConnection Conn
        {
            get;
        }

        /// <summary>
        /// 获取所有的预占库存
        /// </summary>
        /// <returns></returns>
        IEnumerable<InventoryIncreaseEvent> FindInventoryIncreaseEvent();

        /// <summary>
        /// 根据where条件获取预占库存
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str);

        /// <summary>
        /// 根据where条件获取预占库存，参数化方式。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str ,object obj);

        InventoryIncreaseEvent GetInventoryIncreaseEventById(string id);

        int UpdateInventoryIncreaseEvent(InventoryIncreaseEvent obj);
        int InsertInventoryIncreaseEvent(InventoryIncreaseEvent obj);
        int DeleteInventoryIncreaseEvent(InventoryIncreaseEvent obj);
        int DeleteInventoryIncreaseEvent( );
    }
}
