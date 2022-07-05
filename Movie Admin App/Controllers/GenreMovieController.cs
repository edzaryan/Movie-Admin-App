using Microsoft.AspNetCore.Mvc;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    public class GenreMovieController : ControllerBase
    {
        private readonly ApplicationContext context;

        public GenreMovieController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpPost("{movieId:int}")]
        public async Task<IActionResult> CreateGenreMovie([FromRoute] int movieId, [FromBody] int genreId)
        {
            try
            {
                await context.GenreMovies.AddAsync(new GenreMovie { GenreId = genreId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(genreId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while adding genreMovie");
            }
        }


        [HttpDelete("{movieId:int}/{genreId:int}")]
        public async Task<IActionResult> DeleteGenreMovie([FromRoute] int movieId, [FromRoute] int genreId)
        {
            try
            {
                context.GenreMovies.Remove(new GenreMovie { GenreId = genreId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(genreId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while deleting genreMovie");
            }
        }

    }
}
