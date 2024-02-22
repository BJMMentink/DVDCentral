using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BJM.DVDCentral.BL;
using BJM.DVDCentral.BL.Models;
using Microsoft.EntityFrameworkCore;
using BJM.DVDCentral.PL2.Data;

namespace BJM.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly ILogger<GenresController> logger;

        public GenresController(ILogger<GenresController> logger, DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }
        
        /// <summary>
        /// Get a list of movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return new GenreManager(options).Load();
        }

        /// <summary>
        /// Return a particular Genre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Genre Get(Guid id)
        {
            return new GenreManager(options).LoadById(id);
        }
        /// <summary>
        /// Insert a genre
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="rollback">Should be rollback the transaction</param>
        /// <returns></returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Genre genre, bool rollback = false)
        {
            try
            {
                return new GenreManager(options).Insert(genre, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Update a Genre
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="id"></param>
        /// <param name="rollback">Should be rollback the transaction</param>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]        
        public int Put([FromBody] Genre genre, Guid id, bool rollback = false)
        {
            try
            {
                return new GenreManager(options).Update(genre, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete a genre
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rollback">Should be rollback the transaction</param>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new GenreManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
