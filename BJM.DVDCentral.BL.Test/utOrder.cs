
namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrders
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, OrderManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Order orders = new Order
            {
                CustomerId = -99,
                UserId = -99,
                ShipDate = DateTime.Now,
                OrderDate = DateTime.Now,
                Items = new List<OrderItem> { new OrderItem { } }
            };

            int results = OrderManager.Insert(orders, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order orders = OrderManager.LoadById(3);
            orders.ShipDate = DateTime.Now;
            int results = OrderManager.Update(orders, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}