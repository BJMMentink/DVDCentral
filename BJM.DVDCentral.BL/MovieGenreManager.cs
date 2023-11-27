/**/
using System.Xml.Linq;
using BJM.DVDCentral.PL;
using BJM.DVDCentral.BL.Models;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage;

namespace BJM.DVDCentral.BL
{
    public class MovieGenreManager
    {
        public static void Insert(int MovieId, int GenreId, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre MovieGenre = new tblMovieGenre();
                    MovieGenre.GenreId = GenreId;
                    MovieGenre.MovieId = MovieId;
                    MovieGenre.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(sa => sa.Id) + 1 : 1;

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
        public static int Delete(int MovieId, int GenreId, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre? tblmovieGenre = dc.tblMovieGenres.FirstOrDefault(s => s.Id == MovieId && s.GenreId == GenreId);
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
       
    }
}
/**/