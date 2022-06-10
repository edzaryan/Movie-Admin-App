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


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            try
            {
                var country = await context.Countries.Select(c => new
                {
                    c.Id,
                    c.Name,
                }).FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(country);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting the Country from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetCountry([FromQuery]string v)
        {
            try
            {
                var countries = await context.Countries.Where(c => c.Name.Contains(v)).ToListAsync();

                return Ok(countries);
            } 
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting the countries from the database");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a country in database");
            }
        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateCountry([FromQuery] int id, [FromForm] Country model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }

                var country = await context.Countries.FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                {
                    return NotFound();
                }

                country.Name = model.Name;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetCountryById), new { id = country.Id });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the country in database");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the country in database");
            }
        }

    }
}
