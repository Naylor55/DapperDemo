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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DapperDemo.persistence
{
    public class InventoryIncreaseEventRepositorylmpl : PersistenceBase, IInventoryIncreaseEventRepository
    {
        #region init dbconnection       
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                _conn = new SqlConnection(connString);
                _conn.Open();
                return _conn;
            }
        }

        #endregion


        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InventoryAvailableQtyIincreaseEvent> FindInventoryIncreaseEvent()
        {
            using (Conn)
            {
                return Conn.GetList<InventoryAvailableQtyIincreaseEvent>();
            }
        }


        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryAvailableQtyIincreaseEvent> FindInventoryIncreaseEventWhere(string str)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryAvailableQtyIincreaseEvent>(str).ToList();
            }
        }

        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryAvailableQtyIincreaseEvent> FindInventoryIncreaseEventWhere(string str, object obj)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryAvailableQtyIincreaseEvent>(str, obj).ToList();
            }
        }

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryAvailableQtyIincreaseEvent GetInventoryIncreaseEventById(string id)
        {
            using (Conn)
            {
                return Conn.Get<InventoryAvailableQtyIincreaseEvent>(id);
            }
        }

        /// <summary>
        /// 更新库存增长事件记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateInventoryIncreaseEvent(InventoryAvailableQtyIincreaseEvent obj)
        {
            using (Conn)
            {
                return Conn.Update(obj);
            }
        }

        /// <summary>
        /// 新增库存增长事件记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertInventoryIncreaseEvent(InventoryAvailableQtyIincreaseEvent obj)
        {
            using (Conn)
            {
                return (int)Conn.Insert(obj);
            }
        }

        /// <summary>
        /// 删除库存增长事件记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteInventoryIncreaseEvent(InventoryAvailableQtyIincreaseEvent obj)
        {
            using (Conn)
            {
                return Conn.Delete(obj);
            }
        }

        /// <summary>
        /// 删除所有库存增长事件记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteInventoryIncreaseEvent()
        {
            using (Conn)
            {
                return Conn.Execute("delete  InventoryIncreaseEvent");
            }
        }
    }
}
