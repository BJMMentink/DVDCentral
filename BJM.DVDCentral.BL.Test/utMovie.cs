

using System.Xml.Linq;

namespace BJM.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, MovieManager.Load().Count);
        }
        [TestMethod]
        public void InsertTest()
        {
            Movie movie = new Movie
            {
                InStkQty = -99,
                ImagePath = "Test",
                Title = "Test",
                FormatId = -99,
                Id = -99,
                Description = "Test",
                Cost = -99,
                RatingId = 1,
                DirectorId = 1
        };

            int results = MovieManager.Insert(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Movie movie = MovieManager.LoadById(3);
            movie.ImagePath = "Test";
            int results = MovieManager.Update(movie, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = MovieManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }
    }
}