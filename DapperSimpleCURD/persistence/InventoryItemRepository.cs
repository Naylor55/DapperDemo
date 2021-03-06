﻿/********************************************************************************
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
    public interface InventoryItemRepository
    {
        IDbConnection Conn
        {
            get;
        }

        /// <summary>
        /// 获取所有的预占库存
        /// </summary>
        /// <returns></returns>
        List<InventoryItem> FindInventoryItem();

        /// <summary>
        /// 根据where条件获取预占库存
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        List<InventoryItem> FindInventoryItemWhere(string str);

        /// <summary>
        /// 根据where条件获取预占库存，参数化方式。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<InventoryItem> FindInventoryItemWhere(string str, object obj);

        InventoryItem GetInventoryItemById(string id);
        InventoryItem GetInventoryItemBySkuId(int warehouseId, int skuId);
        int UpdateInventoryItem(InventoryItem obj);
        int InsertInventoryItem(InventoryItem obj);
        int DeleteInventoryItem(InventoryItem obj);
        IEnumerable<service.Dtos.WaitPickingOrderDto> GetWaitPickingOrder(int branchId);
    }
}
