namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, OrderItemManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            OrderItem orderItem = new OrderItem
            {
                OrderId = -99,
                MovieId = -99,
                Quantity = -99,
                Cost = -99
            };

            int results = OrderItemManager.Insert(orderItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            OrderItem orderItem = OrderItemManager.LoadById(3);
            orderItem.Cost = -99;
            int results = OrderItemManager.Update(orderItem, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderItemManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}