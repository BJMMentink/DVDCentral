namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase<tblCustomer>
    {
        [TestMethod]
        public void mLoadTest()
        {
            int expected = 3;
            var customers = base.LoadTest();
            Assert.AreEqual(expected, customers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer newRow = new tblCustomer();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";
            newRow.Address = "XXXXXX";
            newRow.City = "Greenville";
            newRow.State = "WI";
            newRow.ZIP = "54942";
            newRow.Phone = "xxx-xxx-xxxx";
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;

            dc.tblCustomers.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblCustomer row = dc.tblCustomers.FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Test";
                row.LastName = "Test";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblCustomer row = dc.tblCustomers.FirstOrDefault();

            if (row != null)
            {
                dc.tblCustomers.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
