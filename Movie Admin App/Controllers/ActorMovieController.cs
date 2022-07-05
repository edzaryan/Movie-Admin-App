using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class ActorMovieController : ControllerBase
    {
        private readonly ApplicationContext context;

        public ActorMovieController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpPost("{movieId:int}")]
        public async Task<IActionResult> CreateActorMovie([FromRoute] int actorId, [FromBody] int movieId)
        {
            try
            {
                await context.ActorMovies.AddAsync(new ActorMovie { ActorId = actorId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(movieId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while adding the movie to actor's movie list");
            }
        }


        [HttpDelete("{movieId:int}/{actorId:int}")]
        public async Task<IActionResult> DeleteActorMovie([FromRoute] int movieId, [FromRoute] int actorId)
        {
            try
            {
                context.ActorMovies.Remove(new ActorMovie { ActorId = actorId, MovieId = movieId });

                await context.SaveChangesAsync();

                return Ok(movieId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while removing the movie from actor's movie list");
            }
        }

    }
}
