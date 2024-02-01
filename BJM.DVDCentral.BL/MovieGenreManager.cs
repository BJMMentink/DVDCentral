/**/


namespace BJM.DVDCentral.BL
{
    public class MovieGenreManager
    {
        public static void Insert(Guid MovieId, Guid GenreId, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre MovieGenre = new tblMovieGenre();
                    MovieGenre.GenreId = GenreId;
                    MovieGenre.MovieId = MovieId;
                    MovieGenre.Id = Guid.NewGuid();

                    dc.tblMovieGenres.Add(MovieGenre);
                    dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Update(Movie movie, Genre genre, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.MovieId == movie.Id && s.GenreId == genre.Id);
                    if (entity != null)
                    {
                        entity.MovieId = movie.Id;
                        entity.GenreId = genre.Id;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Delete(Guid MovieId, Guid GenreId, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback == true) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre tblmovieGenre = dc.tblMovieGenres.FirstOrDefault(s => s.GenreId == GenreId && s.MovieId == MovieId);
                    if (tblmovieGenre != null)
                    {
                        dc.tblMovieGenres.Remove(tblmovieGenre);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Genre> LoadById(Guid movieId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var genres = (from mg in dc.tblMovieGenres
                                  join g in dc.tblGenres on mg.GenreId equals g.Id
                                  where mg.MovieId == movieId
                                  select new Genre
                                  {
                                      Id = mg.GenreId,
                                      Description = g.Description,
                                  }).ToList();

                    return genres;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<string> LoadByMovieId(Guid movieId)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var genreDescriptions = (from mg in dc.tblMovieGenres
                                             join g in dc.tblGenres on mg.GenreId equals g.Id
                                             where mg.MovieId == movieId
                                             select g.Description).ToList();

                    return genreDescriptions;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
/**/