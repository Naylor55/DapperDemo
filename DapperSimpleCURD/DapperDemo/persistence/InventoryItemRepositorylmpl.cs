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
    public class InventoryItemRepositorylmpl : PersistenceBase, InventoryItemRepository
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
        public List<InventoryItem> FindInventoryItem()
        {
            using (Conn)
            {
                return Conn.GetList<InventoryItem>().ToList();
            }
        }

        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryItem> FindInventoryItemWhere(string str)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryItem>(str).ToList();
            }
        }

        /// <summary>
        /// 根据where条件获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public List<InventoryItem> FindInventoryItemWhere(string str, object obj)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryItem>(str, obj).ToList();
            }
        }

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InventoryItem GetInventoryItemById(string id)
        {
            using (Conn)
            {
                return Conn.Get<InventoryItem>(id);
            }
        }

        public InventoryItem GetInventoryItemBySkuId(int warehouseId, int skuId)
        {
            using (Conn)
            {
                return Conn.GetList<InventoryItem>(" where WarehouseId=" + warehouseId + " and SkuId=" + skuId).FirstOrDefault();
            }
        }

        public int UpdateInventoryItem(InventoryItem obj)
        {
            using (Conn)
            {
                return Conn.Update(obj);
            }
        }
        public int InsertInventoryItem(InventoryItem obj)
        {
            using (Conn)
            {
                return (int)Conn.Insert(obj);
            }
        }
        public int DeleteInventoryItem(InventoryItem obj)
        {
            using (Conn)
            {
                return Conn.Delete(obj);
            }
        }


        public IEnumerable<service.Dtos.WaitPickingOrderDto> GetWaitPickingOrder(int branchId)
        {
            using (Conn)
            {
                return Conn.Query<service.Dtos.WaitPickingOrderDto>(string.Format(@"select match.OrderId , c.StartOrder , o.ComId , o.Company as CompanyName ,o.DeptName ,o.DeptId ,match.Status as IsMatch , o.Emergency as  IsUrgent ,o.IsInner,o.RowNum as RowNumber ,o.SumMoney,o.OrderTime as OrderCreateTime ,o.PlanDate as PlanDeliveryDate ,o.Memo   
                from OrderInventoryMatch match left
                join [order] o on match.OrderId = o.Id
                join Customer c  on o.ComId = c.ComId
                join OrderStatus os  on o.Id = os.OrderId
                where match.BranchId = {0} and   o.RawOrderId = 0 and o.IsDelete = 0  and o.ComId != 1  and o.OrderType in ('销售开单', '网上订单', '礼品兑换', '手机商城')
                and os.StoreStatus = '未处理'  and os.ServiceStatus = '已完成'and c.StartOrder = 0 ", branchId));
            }
        }
    }
}
