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
using DapperDemo.service.Dtos;

namespace DapperDemo.service
{
    public class InventoryItemServiceslmpl : IInventoryItemServices
    {
        private static readonly InventoryItemRepository repository = new InventoryItemRepositorylmpl();
        private static readonly InventoryOperationLogRepository logRepository = new InventoryOperationLogRepositorylmpl();
        private static readonly OrderDetailRepository odRepository = new OrderDetailRepositorylmpl();
        private static readonly IInventoryIncreaseEventRepository increaseRepository = new InventoryIncreaseEventRepositorylmpl();
        private static readonly IOrderInventoryMatchRepository matchRepository = new OrderInventoryMatchRepositorylmpl();

        public List<InventoryItem> FindInventoryItem()
        {
            return repository.FindInventoryItem();
        }

        public List<InventoryItem> FindInventoryItemWhere(string str)
        {
            return repository.FindInventoryItemWhere(str);
        }

        public List<InventoryItem> FindInventoryItemWhere(string str, object obj)
        {
            return repository.FindInventoryItemWhere(str, obj);
        }

        public InventoryItem GetInventoryItemById(string id)
        {
            return repository.GetInventoryItemById(id);
        }

        public int UpdateInventoryItem(InventoryItem obj)
        {
            return repository.UpdateInventoryItem(obj);
        }

        public int InsertInventoryItem(InventoryItem obj)
        {
            return repository.InsertInventoryItem(obj);
        }

        public int DeleteInventoryItem(InventoryItem obj)
        {
            return repository.DeleteInventoryItem(obj);
        }

        /// <summary>
        /// 更新预占库存
        /// </summary>
        /// <param name="obj">预占库存实体</param>
        /// <param name="operation">操作标识：0：增加预占；1：减少预占</param>
        /// <returns></returns>
        public bool UpdateInventoryAssignedQty(UpdateInventoryItemDto obj)
        {
            InventoryItem item = repository.GetInventoryItemBySkuId(obj.WarehouseId, obj.SkuId);
            int? assignedQtyBefore = item.AssignedQty;
            item.AssignedQty = obj.Action == 0 ? (item.AssignedQty + obj.AssignedQty) : (item.AssignedQty - obj.AssignedQty);
            item.UpdateTime = DateTime.Now;
            if (repository.UpdateInventoryItem(item) > 0)
            {
                InventoryOperationLog log = new InventoryOperationLog
                {
                    WarehouseId = obj.WarehouseId,
                    SkuId = obj.SkuId,
                    Action = obj.Action,
                    OperationType = obj.OperationType,
                    AvailableQtyAfter = 0,
                    AvailableQtyBefore = 0,
                    AvailableQtyChange = 0,
                    AssignedQtyBefore = assignedQtyBefore,
                    AssignedQtyChange = obj.AssignedQty,
                    AssignedQtyAfter = item.AssignedQty,
                    OrderId = obj.RelationOrderId,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = obj.UpdateUserId
                };
                if (logRepository.InsertInventoryItem(log) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 更新可用库存
        /// </summary>
        /// <param name="obj">预占库存实体</param>
        /// <param name="operation">操作标识：0：增加可用；1：减少可用</param>
        /// <returns></returns>
        public bool UpdateInventoryAvailableQty(UpdateInventoryItemDto obj)
        {
            InventoryItem item = repository.GetInventoryItemBySkuId(obj.WarehouseId, obj.SkuId);
            int? availableQtyBefore = item.AvailableQty;
            item.AvailableQty = obj.Action == 2 ? (item.AvailableQty + obj.AssignedQty) : (item.AvailableQty - obj.AssignedQty);
            item.UpdateTime = DateTime.Now;
            if (repository.UpdateInventoryItem(item) > 0)
            {
                InventoryOperationLog log = new InventoryOperationLog
                {
                    WarehouseId = obj.WarehouseId,
                    SkuId = obj.SkuId,
                    Action = obj.Action,
                    OperationType = obj.OperationType,
                    AvailableQtyBefore = availableQtyBefore,
                    AvailableQtyChange = obj.AvailableQty,
                    AvailableQtyAfter = item.AvailableQty,
                    AssignedQtyBefore = 0,
                    AssignedQtyChange = 0,
                    AssignedQtyAfter = 0,
                    OrderId = obj.RelationOrderId,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    UpdateUserId = obj.UpdateUserId
                };
                if (logRepository.InsertInventoryItem(log) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断订单能否配齐
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public bool CheckOrderIsMatch(int warehouseId, int orderId)
        {
            int temp = 0;
            IEnumerable<OrderDetail> odList = odRepository.GetOrderDetailByOrderId(orderId);


            foreach (OrderDetail item in odList)
            {
                int inventoryNum = (int)repository.GetInventoryItemBySkuId(warehouseId, item.GoodsId).AssignedQty;
                if (item.Num <= inventoryNum)
                {
                    temp++;
                }
            }
            if (temp > 0 && temp == odList.Count())
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 刷新订单配齐状态(定时任务)
        /// </summary>
        public void ReferenceOrderInventoryMatch()
        {
            IEnumerable<InventoryIncreaseEvent> increaseList = increaseRepository.FindInventoryIncreaseEvent();
            foreach (InventoryIncreaseEvent item in increaseList)
            {
                int warehouseId = item.WarehouseId;
                IEnumerable<OrderInventoryMatch> matchList = matchRepository.FindOrderInventoryMatchWhere(" where BranchId=" + item.BranchId);
                foreach (OrderInventoryMatch m in matchList)
                {
                    if (CheckOrderIsMatch(warehouseId, m.OrderId))
                    {
                        //可配齐
                        m.Status = 1;
                    }
                    else
                    {
                        //不可配齐
                        m.Status = 0;
                    }
                    m.UpdateTime = DateTime.Now;
                    matchRepository.UpdateOrderInventoryMatch(m);
                }
            }
        }

        /// <summary>
        /// 获取等待分配拣货员的订单数据
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public IEnumerable<WaitPickingOrderDto> GetWaitPickingOrder(int branchId)
        {
            return repository.GetWaitPickingOrder(branchId);
        }

    }
}
