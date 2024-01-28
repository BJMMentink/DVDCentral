namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var customers = dc.tblCustomers;
            Assert.AreEqual(expected, customers.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblCustomer newRow = new tblCustomer();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Test";
            newRow.LastName = "Test";
            newRow.Address = "Test";
            newRow.City = "Test";
            newRow.State = "Test";
            newRow.ZIP = "Test";
            newRow.Phone = "Test";
            newRow.UserId = dc.tblUsers.FirstOrDefault().Id;

            dc.tblCustomers.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
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
            InsertTest();

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