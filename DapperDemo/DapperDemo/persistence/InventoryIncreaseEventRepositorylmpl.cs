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
    public class InventoryIncreaseEventRepositorylmpl : PersistenceBase, InventoryIncreaseEventRepository
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
        public IEnumerable  <InventoryIncreaseEvent> FindInventoryIncreaseEvent()
        {
            using (Conn)
            {
                return Conn.GetList<InventoryIncreaseEvent>();
            }
        }


        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryIncreaseEvent>(str).ToList();
            }
        }

        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryIncreaseEvent> FindInventoryIncreaseEventWhere(string str, object obj)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryIncreaseEvent>(str, obj).ToList();
            }
        }

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryIncreaseEvent GetInventoryIncreaseEventById(string id)
        {
            using (Conn)
            {
                return Conn.Get<InventoryIncreaseEvent>(id);
            }
        }

        public int UpdateInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            using (Conn)
            {               
                return Conn.Update(obj);
            }
        }
        public int InsertInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            using (Conn)
            {
                return (int)Conn.Insert(obj);                
            }
        }
        public int DeleteInventoryIncreaseEvent(InventoryIncreaseEvent obj)
        {
            using (Conn)
            {
                return Conn.Delete(obj);
            }
        }
    }
}
