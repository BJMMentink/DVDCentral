using Humanizer;

namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie
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
            Assert.AreEqual(3, dc.tblMovie.Count());
        }
        [TestMethod]
        public void InsertTest()
        {
            tblMovie entity = new tblMovie();
            entity.InStkQty = -99;
            entity.ImagePath = "Test";
            entity.Title = "Test";
            entity.FormatId = -99;
            entity.Id = -99;
            entity.Description = "Test";
            entity.Cost = -99;
            entity.RatingId = 1;
            entity.FormatId = 1;
            entity.DirectorId = 1;

            dc.tblMovie.Add(entity);

            int result = dc.SaveChanges();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UpdateTest()
        {
            tblMovie entity = dc.tblMovie.FirstOrDefault();

            entity.ImagePath = "Test";
            entity.Title = "Test";

            int result = dc.SaveChanges();
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            tblMovie entity = dc.tblMovie.Where(e => e.Id == 1).FirstOrDefault();
            dc.tblMovie.Remove(entity);
            int result = dc.SaveChanges();
            Assert.AreNotEqual(result, 0);
        }
        [TestMethod]
        public void LoadByIdTest()
        {
            tblMovie entity = dc.tblMovie.Where(e => e.Id == 1).FirstOrDefault();
            Assert.AreEqual(entity.Id, 1);
        }
    }
}
