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
using DapperDemo.service.Dtos;

namespace DapperDemo.service
{
    public interface InventoryItemServices
    {
        #region Start-BaseInterface
        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        List<InventoryItem> FindInventoryItem();

        List<InventoryItem> FindInventoryItemWhere(string str);

        /// <summary>
        /// 根据where条件获取预占库存，参数化方式。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<InventoryItem> FindInventoryItemWhere(string str, object obj);

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        InventoryItem GetInventoryItemById(string id);

        int UpdateInventoryItem(InventoryItem obj);

        int InsertInventoryItem(InventoryItem obj);

        int DeleteInventoryItem(InventoryItem obj);
        #endregion End-BaseInterface

        #region Start-ExtendInterface
        bool UpdateInventoryAssignedQty(UpdateInventoryItemDto obj);

        bool UpdateInventoryAvailableQty(UpdateInventoryItemDto obj);

        /// <summary>
        /// 检查订单能否配齐
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        bool CheckOrderIsMatch(int warehouseId, int orderId);

        /// <summary>
        /// 刷新订单配齐状态(定时任务)
        /// </summary>
        void ReferenceOrderInventoryMatch();

        #endregion End-ExtendInterface
    }
}
