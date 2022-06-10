﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetGenre(string v)
        {
            var genres = await context.Genres.Where(g => g.Name.Contains(v)).ToListAsync();

            return Ok(genres);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return NotFound("There is not a genre with id: " + id);
            }

            return Ok(genre);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetGenres([FromQuery] int page=1)
        {
            var genres = await context.Genres
                    .Skip(page == 1 ? 0 : page * 16 - 16)
                    .Take(16)
                    .Select(e => new
                    {
                        e.Id,
                        e.Name,
                    })
                    .ToListAsync();

            return Ok(genres);
        }


        public async Task<IActionResult> CreateGenre([FromForm] Genre model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await context.Genres.AddAsync(model);

            return RedirectToAction(nameof(GetGenres));
        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateGenre([FromRoute] int id, [FromForm] Genre model)
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


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre([FromQuery] int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return NotFound("There is not a genre with id: " + id);
            }

            context.Genres.Remove(genre);

            return RedirectToAction(nameof(GetGenres));
        }

    }
}