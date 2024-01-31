namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem : utBase<tblOrderItem>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var orderItems = base.LoadTest();
            Assert.AreEqual(expected, orderItems.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblOrderItem newRow = new tblOrderItem();

            newRow.Id = Guid.NewGuid();
            newRow.MovieId = dc.tblMovies.FirstOrDefault().Id;
            newRow.Quantity = 99;
            newRow.Cost = 9.99;

            dc.tblOrderItems.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblOrderItem row = dc.tblOrderItems.FirstOrDefault();

            if (row != null)
            {
                row.MovieId = dc.tblMovies.FirstOrDefault().Id; ;
                row.Quantity = 100;
                row.Cost = 10.99;
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {

            tblOrderItem row = dc.tblOrderItems.FirstOrDefault();

            if (row != null)
            {
                dc.tblOrderItems.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }

}
