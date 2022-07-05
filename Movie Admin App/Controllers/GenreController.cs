using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationContext context;

        public GenreController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetGenre([FromQuery] string v)
        {
            try
            {
                var genres = await context.Genres.OrderBy(g => g.Name).Where(g => g.Name.Contains(v)).ToListAsync();

                return Ok(genres);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while retrieving genres");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateGenre([FromForm] Genre model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await context.Genres.AddAsync(model);

                return Ok("The genre created successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while creating a new genre");
            }
        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateGenre([FromRoute] int id, [FromForm] Genre model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return NotFound("There isn't a genre with id: " + id);
                }

                genre.Name = model.Name;

                await context.SaveChangesAsync();

                return Ok(genre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the genre");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre([FromQuery] int id)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return NotFound("There is not a genre with id: " + id);
                }

                context.Genres.Remove(genre);

                return Ok("The genre deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while deleting the genre");
            }
        }

    }
}
