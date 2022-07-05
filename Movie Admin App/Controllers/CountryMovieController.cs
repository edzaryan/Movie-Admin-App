using Microsoft.AspNetCore.Mvc;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    public class CountryMovieController : Controller
    {
        private readonly ApplicationContext context;

        public CountryMovieController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpPost("{movieId:int}")]
        public async Task<IActionResult> CreateCountryMovie([FromRoute] int movieId, [FromBody] int countryId)
        {
            try
            {
                await context.CountryMovies.AddAsync(new CountryMovie { CountryId = countryId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(countryId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while adding countryMovie");
            }
        }


        [HttpDelete("{movieId:int}/{genreId:int}")]
        public async Task<IActionResult> DeleteCountryMovie([FromRoute] int movieId, [FromRoute] int countryId)
        {
            try
            {
                context.CountryMovies.Remove(new CountryMovie { CountryId = countryId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(countryId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while deleting countryMovie");
            }
        }
    }
}
