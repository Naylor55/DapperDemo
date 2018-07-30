using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.service.Dtos
{
    public class UpdateInventoryItemDto
    {
        public int WarehouseId { get; set; }
        public int SkuId { get; set; }
        public int? AvailableQty { get; set; }
        public int? AssignedQty { get; set; }
        public int RelationOrderId { get; set; }
        public int UpdateUserId { get; set; }
        public string OperationType { get; set; }
        /// <summary>
        /// 操作标识：0=增加预占；1=减少预占；2=增加可用；3=减少可用
        /// </summary>
        public int Action { get; set; }
    }
}
