using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BJM.DVDCentral.BL;
using BJM.DVDCentral.BL.Models;

namespace BJM.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Genre> GetGenres()
        {
            return GenreManager.Load();
        }

        
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return GenreManager.LoadById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            try
            {
                int results = GenreManager.Insert(genre);
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
                int results = GenreManager.Update(genre);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int results = GenreManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
