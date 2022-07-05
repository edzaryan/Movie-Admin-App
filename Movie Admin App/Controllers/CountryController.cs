using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Data;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationContext context;

        public CountryController(ApplicationContext context)
        {
            this.context = context;
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetCountry([FromQuery] string v)
        {
            try
            {
                var countries = await context.Countries.OrderBy(c => c.Name).Where(c => c.Name.Contains(v)).ToListAsync();

                return Ok(countries);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while retrieving genres from database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateCountry([FromForm] Country model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                Country new_country = new()
                {
                    Name = model.Name,
                };

                await context.Countries.AddAsync(new_country);

                await context.SaveChangesAsync();

                return RedirectToAction("GetActors", "Actor");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while creating country");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCountry([FromRoute] int id, [FromForm] Country model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var country = await context.Countries.FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                {
                    return NotFound("There isn't a country with id: " + id);
                }

                country.Name = model.Name;

                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the country");
            }
        }


        [HttpDelete("")]
        public async Task<IActionResult> DeleteCountry([FromQuery] int id)
        {
            try
            {
                var country = await context.Countries.FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                {
                    return NotFound();
                }

                context.Countries.Remove(country);

                return RedirectToAction(nameof(GetCountry));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while deleting the country");
            }
        }

    }
}
