namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat
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
            Assert.AreEqual(4, dc.tblFormats.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            tblFormat entity = new tblFormat();
            entity.Description = "Test";
            entity.Id = -99;

            dc.tblFormats.Add(entity);

            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UpdateTest()
        {
            tblFormat entity = dc.tblFormats.FirstOrDefault();

            entity.Description = "Test";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            tblFormat entity = dc.tblFormats.Where(e => e.Id == 1).FirstOrDefault();
            dc.tblFormats.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            tblFormat entity = dc.tblFormats.Where(e => e.Id == 1).FirstOrDefault();
            Assert.AreEqual(entity.Id, 1);
        }
    }
}
