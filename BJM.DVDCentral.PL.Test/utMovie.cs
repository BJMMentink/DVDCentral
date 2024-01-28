

namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 6;
            var movies = dc.tblMovies;
            Assert.AreEqual(expected, movies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovie newRow = new tblMovie();

            newRow.Id = Guid.NewGuid();
            newRow.Title = "XXXXX";
            newRow.Description = "XXXXX";
            newRow.Cost = 9.99;
            newRow.RatingId = dc.tblRatings.FirstOrDefault().Id;
            newRow.FormatId = dc.tblFormats.FirstOrDefault().Id;
            newRow.DirectorId = dc.tblDirectors.FirstOrDefault().Id;
            newRow.Quantity = 0;
            newRow.ImagePath = "none";

            dc.tblMovies.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            tblMovie row = dc.tblMovies.FirstOrDefault();

            if (row != null)
            {
                row.Description = "YYYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblMovie row = dc.tblMovies.FirstOrDefault();

            if (row != null)
            {
                dc.tblMovies.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}
