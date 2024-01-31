namespace BJM.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovieGenre : utBase<tblMovieGenre>
    {


        [TestMethod]
        public void LoadTest()
        {
            int expected = 13;
            var movieGenres = base.LoadTest();
            Assert.AreEqual(expected, movieGenres.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            tblMovieGenre newRow = new tblMovieGenre();

            newRow.Id = Guid.NewGuid();
            newRow.MovieId = dc.tblMovies.FirstOrDefault().Id;
            newRow.GenreId = dc.tblGenres.FirstOrDefault().Id;

            dc.tblMovieGenres.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);


        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMovieGenre row = dc.tblMovieGenres.FirstOrDefault();

            if (row != null)
            {
                row.MovieId = dc.tblMovies.FirstOrDefault().Id;
                row.GenreId = dc.tblGenres.FirstOrDefault().Id;
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            tblMovieGenre row = dc.tblMovieGenres.FirstOrDefault();

            if (row != null)
            {
                dc.tblMovieGenres.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}

