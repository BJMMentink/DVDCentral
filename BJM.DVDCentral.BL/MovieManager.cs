using System.Xml.Linq;
using BJM.DVDCentral.PL;
using BJM.DVDCentral.BL.Models;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage;
using static Azure.Core.HttpHeader;

namespace BJM.DVDCentral.BL
{
    public class MovieManager
    {
        public static int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = new tblMovie();
                    entity.Id = dc.tblMovie.Any() ? dc.tblMovie.Max(s => s.Id) + 1 : 1;
                    entity.Description = movie.Description;
                    entity.InStkQty = movie.InStkQty;
                    entity.ImagePath = movie.ImagePath;
                    entity.Title = movie.Title;
                    entity.FormatId = movie.FormatId;
                    entity.Cost = movie.Cost;
                    entity.RatingId = movie.RatingId;
                    entity.DirectorId = movie.DirectorId;
                    movie.Id = entity.Id;
                    dc.tblMovie.Add(entity);
                    results = dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = dc.tblMovie.FirstOrDefault(s => s.Id == movie.Id);
                    if (entity != null)
                    {
                        entity.Description = movie.Description;
                        entity.InStkQty = movie.InStkQty;
                        entity.ImagePath = movie.ImagePath;
                        entity.Title = movie.Title;
                        entity.FormatId = movie.FormatId;
                        entity.Cost = movie.Cost;
                        entity.RatingId = movie.RatingId;
                        entity.DirectorId = movie.DirectorId;
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
        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = dc.tblMovie.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblMovie.Remove(entity);
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
        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie entity = dc.tblMovie.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Movie
                        {
                            Id = entity.Id,
                            Description = entity.Description,
                            InStkQty = entity.InStkQty,
                            ImagePath = entity.ImagePath,
                            Title = entity.Title,
                            FormatId = entity.FormatId,
                            Cost = (float)entity.Cost,
                            RatingId = entity.RatingId,
                            DirectorId = entity.DirectorId

                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Movie> Load(int? movieId = null)
        {
            try
            {
                List<Movie> list = new List<Movie>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblMovie
                     join d in dc.tblDirectors on 
                     s.DirectorId equals d.Id 
                     join r in dc.tblRatings on
                     s.RatingId equals r.Id
                     join f in dc.tblFormats on
                     s.FormatId equals f.Id
                     where s.Id == movieId || movieId == null
                     select new
                     {
                         s.Id,
                         s.Description,
                         s.InStkQty,
                         s.ImagePath,
                         s.Title,
                         s.FormatId,
                         s.Cost,
                         s.RatingId,
                         s.DirectorId,
                         DirectorName = d.FirstName + " " + d.LastName,
                         RatingDescription = r.Description,
                         FormatDescription = f.Description,


                     })
                     .ToList()
                     .ForEach(movie => list.Add(new Movie
                     {
                         Id = movie.Id,
                         Description = movie.Description,
                         InStkQty = movie.InStkQty,
                         ImagePath = movie.ImagePath,
                         Title = movie.Title,
                         FormatId = movie.FormatId,
                         Cost = (float)movie.Cost,
                         RatingId = movie.RatingId,
                         DirectorId = movie.DirectorId,
                         DirectorName = movie.DirectorName,
                         RatingDescription = movie.RatingDescription,
                         FormatDescription = movie.FormatDescription,
                         
                     }));
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
