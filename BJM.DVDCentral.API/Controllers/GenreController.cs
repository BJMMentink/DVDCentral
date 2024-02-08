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
        
        
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return new GenreManager(options).Load();
        }

        
        [HttpGet("{id}")]
        public Genre Get(Guid id)
        {
            return new GenreManager(options).LoadById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            try
            {
                int results = new GenreManager(options).Insert(genre);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Genre genre)
        {
            try
            {
                int results = new GenreManager(options).Update(genre);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                int results = new GenreManager(options).Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
