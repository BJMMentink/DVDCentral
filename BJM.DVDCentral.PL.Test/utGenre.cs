namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
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
            Assert.AreEqual(5, dc.tblGenres.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            tblGenre entity = new tblGenre();
            entity.Description = "Test";
            entity.Id = -99;

            dc.tblGenres.Add(entity);

            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UpdateTest()
        {
            tblGenre entity = dc.tblGenres.FirstOrDefault();

            entity.Description = "Test";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            tblGenre entity = dc.tblGenres.Where(e => e.Id == 1).FirstOrDefault();
            dc.tblGenres.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            tblGenre entity = dc.tblGenres.Where(e => e.Id == 1).FirstOrDefault();
            Assert.AreEqual(entity.Id, 1);
        }
    }
}
