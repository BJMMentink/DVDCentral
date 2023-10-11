using BJM.DVDCentral.PL;

namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, CustomerManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Customer customer = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                Address = "Test",
                City = "Test",
                State = "Test",
                ZIP = "Test",
                Phone = "Test",
                UserId = -99
            };

            int results = CustomerManager.Insert(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = CustomerManager.LoadById(3);
            customer.FirstName = "Test";
            int results = CustomerManager.Update(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = CustomerManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
        [TestMethod]
        public void LoadById()
        {
            int customerIdToLoad = 1;
            Customer loadedCustomer = CustomerManager.LoadById(customerIdToLoad);
            Assert.AreEqual(customerIdToLoad, loadedCustomer.Id);
        }
    }
}