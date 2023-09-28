namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
    {
        protected DVDCentralEntities dc;
        protected IDbContextTransaction transaction;
        [TestInitialize]
        public void Initialize()
        {
            dc = new DVDCentralEntities();
            transaction = dc.Database.BeginTransaction();
        }
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, dc.tblDirectors.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            tblDirector entity = new tblDirector();
            entity.FirstName = "Test";
            entity.LastName = "Test";
            entity.Id = -99;

            dc.tblDirectors.Add(entity);

            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UpdateTest()
        {
            tblDirector entity = dc.tblDirectors.FirstOrDefault();

            entity.FirstName = "Test";
            entity.LastName = "Test";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 1).FirstOrDefault();
            dc.tblDirectors.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            tblDirector entity = dc.tblDirectors.Where(e => e.Id == 1).FirstOrDefault();
            Assert.AreEqual(entity.Id, 1);
        }
    }
}
