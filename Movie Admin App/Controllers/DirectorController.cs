using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly ApplicationContext context;

        public DirectorController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetDirector([FromQuery] int page = 1)
        {
            try
            {
                var directors = await context.Directors
                    .Skip(page == 1 ? 0 : page * 16 - 16)
                    .Take(16)
                    .Select(e => new
                    {
                        e.Id,
                        e.FirstName,
                        e.LastName,
                    })
                    .ToListAsync();

                return Ok(directors);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving directors from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetDirector([FromQuery] string v)
        {
            try
            {
                var directors = await context.Directors.Where(a => (a.FirstName + a.LastName).Contains(v)).ToListAsync();

                return Ok(directors);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving directors from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDirectorById([FromRoute] int id)
        {
            try
            {
                var director = await context.Directors.FirstOrDefaultAsync(a => a.Id == id);

                if (director == null)
                {
                    return NotFound("There is not an director with id: " + id);
                }

                return Ok(director);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving the director from the database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateDirector([FromForm] Director model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var new_director = new Director
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Birthday = model.Birthday,
                    Height = model.Height,
                    Bio = model.Bio,
                    CountryId = model.CountryId
                };

                await context.Directors.AddAsync(new_director);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetDirector));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a director in database");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDirector([FromRoute] int id, [FromForm] Director model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var director = await context.Directors.FirstOrDefaultAsync(a => a.Id == id);

                if (director == null)
                {
                    return BadRequest();
                }

                director.FirstName = model.FirstName;
                director.LastName = model.LastName;
                director.Birthday = model.Birthday;
                director.Height = model.Height;
                director.Bio = model.Bio;
                director.CountryId = model.CountryId;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetDirector));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the director in database");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDirector([FromRoute] int id)
        {
            try
            {
                var director = await context.Directors.FirstOrDefaultAsync(a => a.Id == id);

                if (director == null)
                {
                    return BadRequest();
                }

                context.Directors.Remove(director);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetDirector));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the director from the database");
            }
        }

    }

}
