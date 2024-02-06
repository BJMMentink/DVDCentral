using BJM.DVDCentral.PL2;

namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Customer> customers = new CustomerManager(options).Load();
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
                UserId = new UserManager(options).Load().FirstOrDefault().Id
            };

            int results = CustomerManager.Insert(customer, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customer customer = new CustomerManager(options).Load().FirstOrDefault();
            customer.FirstName = "Test";

            Assert.IsTrue(new CustomerManager(options).Update(customer, true) > 0);
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