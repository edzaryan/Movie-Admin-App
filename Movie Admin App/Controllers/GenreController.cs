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


        [HttpGet("")]
        public async Task<IActionResult> GetGenres([FromQuery] int page = 1)
        {
            try
            {
                //var genres = await context.Genres
                //    .Skip(page == 1 ? 0 : page * 16 - 16)
                //    .Take(16)
                //    .Select(e => new
                //    {
                //        e.Id,
                //        e.Name,
                //        e.Movies
                //    })
                //    .ToListAsync();

                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genre from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetGenre([FromQuery] string v)
        {
            try
            {
                var genres = await context.Genres.Where(g => g.Name.Contains(v)).ToListAsync();

                return Ok(genres);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genre from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int id)
        {
            try
            {
                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return NotFound("There is not a genre with id: " + id);
                }

                return Ok(genre);
            } 
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genre from the database");
            }
        }


        public async Task<IActionResult> CreateGenre([FromForm] Genre model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await context.Genres.AddAsync(model);

                return RedirectToAction(nameof(GetGenres));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a genre from the database");
            }
        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateGenre([FromRoute] int id, [FromForm] Genre model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return NotFound("There isn't a genre with id: " + id);
                }

                genre.Name = model.Name;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetGenres));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the genre in the database");
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

                return RedirectToAction(nameof(GetGenres));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the genre in the database");
            }
        }

    }
}
