using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperDemo.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperDemo.persistence;
using Moq;

namespace DapperDemo.service.Tests
{
    [TestClass()]
    public class InventoryItemServiceslmplTests
    {
        private InventoryItemServiceslmpl inventoryItemServiceslmpl;
        [TestMethod()]
        public void CheckOrderIsMatchTest()
        {
            var mock = new Mock<OrderDetailRepositorylmpl>();
            int orderId = 1;// new Random(3).Next();
            int warehouseId = new Random(2).Next();
            mock.Setup(x => x.GetOrderDetailByOrderId(orderId)).Returns(() =>
            {
                if (orderId == 0)
                    return null;
                else
                    return new List<Models.OrderDetail>();
            });

            inventoryItemServiceslmpl = new InventoryItemServiceslmpl(mock.Object);
            bool result = inventoryItemServiceslmpl.CheckOrderIsMatch(warehouseId, orderId);

            Assert.AreEqual(result, false);
            

         //   Assert.AreEqual(mock.Object.IsEnabled(), true);


           // Assert.Fail();
        }
    }
}