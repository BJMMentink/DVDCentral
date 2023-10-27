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
        [TestMethod]
        public void InsertOrderItemsTest()
        {
            Order order = new Order
            {
                CustomerId = 99,
                OrderDate = DateTime.Now,
                UserId = 99,
                ShipDate = DateTime.Now,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 88,
                        MovieId = 1,
                        OrderId = 2,
                        Cost = 9.99,
                        Quantity = 9,
                    },
                    new OrderItem
                    {
                        Id = 99,
                        OrderId = 4,
                        MovieId = 2,
                        Cost = 8.88,
                        Quantity = 2,
                    },
                }
            };
            int result = OrderManager.Insert(order, true);
            Assert.AreEqual(order.Items[1].OrderId, order.Id);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            int id = OrderManager.Load().LastOrDefault().Id;
            Order order = OrderManager.LoadById(id);
            Assert.AreEqual(order.Id, id);
            Assert.IsTrue(order.Items.Count > 0);
        }
        [TestMethod]
        public void LoadByCustomerIdTest()
        {
            int customerId = OrderManager.Load().LastOrDefault().CustomerId;
            Assert.AreEqual(OrderManager.LoadById(customerId).CustomerId, customerId);
        }
    }
}