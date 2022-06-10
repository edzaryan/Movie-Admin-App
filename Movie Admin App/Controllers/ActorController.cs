using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationContext context;

        public ActorController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetActors([FromQuery] int page=1)
        {
            try
            {
                var actors = await context.Actors
                    .Skip(page == 1 ? 0 : page * 16 - 16)
                    .Take(16)
                    .Select(e => new
                    {
                        e.Id,
                        e.FirstName,
                        e.LastName,
                    })
                    .ToListAsync();

                return Ok(actors);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genres from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetActor([FromQuery] string v)
        {
            try
            {
                var actors = await context.Actors.Where(a => (a.FirstName + a.LastName).Contains(v)).ToListAsync();

                return Ok(actors);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genres from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetActorById([FromRoute] int id)
        {
            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);
                
                if (actor == null)
                {
                    return NotFound("There is not an actor with id: " + id);
                }

                return Ok(actor);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genre from the database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateActor([FromForm] Actor model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var new_actor = new Actor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    Height = model.Height,
                    Bio = model.Bio,
                    PlaceOfBirth = model.PlaceOfBirth,
                };

                await context.Actors.AddAsync(new_actor);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a genre in database");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateActor([FromRoute] int id, [FromForm] Actor model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

                if (actor == null)
                {
                    return BadRequest();
                }

                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.Birthday = model.Birthday;
                actor.Height = model.Height;
                actor.Bio = model.Bio;
                actor.PlaceOfBirth = model.PlaceOfBirth;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the genre in database");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

                if (actor == null)
                {
                    return BadRequest();
                }
                
                context.Actors.Remove(actor);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the genre from the database");
            }
        }

    }

}
