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
    public class OrderDetailRepositorylmpl : PersistenceBase, OrderDetailRepository
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
        /// 根据订单编号获取订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public virtual IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            using (Conn)
            {
                return Conn.GetList<OrderDetail>(" where OrderId=" + orderId);
            }
        }
    }
}
