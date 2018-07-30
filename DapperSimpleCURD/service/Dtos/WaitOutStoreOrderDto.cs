using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.service.Dtos
{
    /// <summary>
    /// 等待出库的订单实体
    /// </summary>
    public class WaitPickingOrderDto
    {
        public int OrderId { get; set; }
        public int ComId { get; set; }
        public string CompanyName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        /// <summary>
        /// 是否货齐
        /// </summary>
        public int IsMatch { get; set; }

        /// <summary>
        /// 是否是紧急订单
        /// </summary>
        public int IsUrgent { get; set; }

        /// <summary>
        /// 是否是勿采勿配订单
        /// </summary>
        public int IsInner { get; set; }

        /// <summary>
        /// 订单明细行数
        /// </summary>
        public int RowNumber { get; set; }

        public decimal Summoney { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public DateTime PlanDeliveryDate { get; set; }
        public string OrderMemo { get; set; }

    }
}
