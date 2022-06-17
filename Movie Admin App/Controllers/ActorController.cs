using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Custom_Functionalities;
using Movie_Admin_App.CustomModels;
using Movie_Admin_App.Data;
using Movie_Admin_App.Data.enums;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IFileOperations fileOperations;

        public ActorController(ApplicationContext context, IFileOperations fileOperations)
        {
            this.context = context;
            this.fileOperations = fileOperations;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetActors([FromQuery] int page = 1)
        {
            try
            {
                var actors = await context.Actors
                                .Include(a => a.ActorMovies)
                                    .ThenInclude(b => b.Movie)
                            //.Skip(page == 1 ? 0 : page * 16 - 16)
                            //.Take(16)
                            .Select(e => new
                            {
                                e.Id,
                                e.FirstName,
                                e.LastName,
                                Movies = e.ActorMovies
                            })
                            .ToListAsync();

                return Ok(actors);
            }
            catch (Exception)
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving the actor from the database");
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving actors from the database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateActor([FromForm] CreateActorModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                string uniqueImageFileName = fileOperations.UploadFile(model.UploadedImage, FileCategory.Image);

                var new_actor = new Actor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    Height = model.Height,
                    Bio = model.Bio,
                    Image = uniqueImageFileName,
                    CountryId = model.CountryId,
                };

                await context.Actors.AddAsync(new_actor);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating an actor in database");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateActor([FromRoute] int id, [FromForm] UpdateActorModel model)
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
                    return NotFound("There is not an actor with id: " + id);
                }

                if (model.FirstName != null)
                {
                    actor.FirstName = model.FirstName;
                }

                if (model.LastName != null)
                {
                    actor.LastName = model.LastName;
                }

                if (model.Birthday != null)
                {
                    actor.Birthday = model.Birthday;
                }

                if (model.Height != null)
                {
                    actor.Height = model.Height;
                }

                if (model.Bio != null)
                {
                    actor.Bio = model.Bio;
                }

                if (model.CountryId != null)
                {
                    actor.CountryId = model.CountryId;
                }

                if (model.UploadedImage != null)
                {
                    fileOperations.DeleteFile(actor.Image, FileCategory.Image);
                    actor.Image = fileOperations.UploadFile(model.UploadedImage, FileCategory.Image);
                }

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the actor in database");
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

                fileOperations.DeleteFile(actor.Image, FileCategory.Image);

                context.Actors.Remove(actor);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetActors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the actor from the database");
            }
        }

    }

}
