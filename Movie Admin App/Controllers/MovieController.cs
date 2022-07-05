using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Custom;
using Movie_Admin_App.Data;
using Movie_Admin_App.Data.enums;
using Movie_Admin_App.Models;
using Movie_Admin_App.Models.MovieModels;
using Movie_Admin_App.Services;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly FileOperations fileOperations;

        public MovieController(ApplicationContext context, FileOperations fileOperations)
        {
            this.context = context;
            this.fileOperations = fileOperations;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetMovies([FromQuery] int page = 1)
        {
            try
            {
                var movies = await context.Movies
                    .Skip(page * 16 - 16)
                    .Take(16)
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Image,
                        Rating = (double)m.Stars / m.Voters,
                        m.Year,
                    })
                    .ToListAsync();

                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving movies from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetMovie([FromQuery] MovieSearchModel model)
        {
            try
            {
                int[] durationBounds = model.dur.Split('-').Select(int.Parse).ToArray();
                int[] yearBounds = model.year.Split('-').Select(int.Parse).ToArray();
                double[] ratingBounds = model.rat.Split('-').Select(double.Parse).ToArray();
                string[] countryList = model.count.Split(',').ToArray();

                int[] popularityBounds = model.pop.Split('-').Select(int.Parse).ToArray();

                var movies = await context.Movies
                    .Where(m =>
                        m.Title.Contains(model.v) &&
                        m.Year >= yearBounds[0] && m.Year <= yearBounds[1] &&
                        m.Duration >= durationBounds[0] && m.Duration <= durationBounds[1] &&
                        (double) m.Stars / m.Voters >= ratingBounds[0] && (double) m.Stars / m.Voters <= ratingBounds[1] && 
                        m.CountryMovies.All(cm => countryList.Contains(cm.Country.Name))
                    ) 
                    .Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.Image,
                    })
                    .ToListAsync();

                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting movies from the database");
            }
        }


        [HttpGet("{id:int}/edit")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            try
            {
                var movie = await context.Movies
                    .Select(m => new
                    {
                        m.Id,
                        m.Title,
                        m.Duration,
                        m.Desc,
                        m.Year,
                        Rating = (double) m.Stars / m.Voters,
                        m.Views,
                        m.Image,
                        m.Video,
                        //m.Director,
                        Genres = m.GenreMovies.Select(gm => new
                        {
                            gm.Genre.Id,
                            gm.Genre.Name
                        }),
                        Countries = m.CountryMovies.Select(cm => new
                        {
                            cm.Country.Id,
                            cm.Country.Name
                        }),
                        Actors = m.ActorMovies.Select(am => new 
                        { 
                            am.Actor.Id, 
                            am.Actor.FirstName,
                            am.Actor.LastName,
                        })
                    }).FirstOrDefaultAsync(m => m.Id == id);

                if (movie == null)
                {
                    return NotFound("There is not a movie with id: " + id);
                }

                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting movie from database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateMovie([FromForm] MovieCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var new_movie = new Movie
                {
                    Title = model.Title,
                    Year = model.Year,
                    Desc = model.Desc,
                };

                if (model.Image != null)
                {
                    string? uniqueImageName = CustomFunctions.GetUniqueFileName(10, Path.GetExtension(model.Image.FileName));

                    fileOperations.UploadFile(model.Image, uniqueImageName, FileCategory.Image);

                    new_movie.Image = uniqueImageName;
                }

                if (model.Video != null)
                {
                    string? uniqueVideoName = CustomFunctions.GetUniqueFileName(10, Path.GetExtension(model.Video.FileName));

                    fileOperations.UploadFile(model.Video, uniqueVideoName, FileCategory.Video);

                    new_movie.Video = uniqueVideoName;
                }

                await context.Movies.AddAsync(new_movie);
                await context.SaveChangesAsync();


                if (model.ActorIds == null)
                {
                    int[] ActorIds = model.ActorIds.Split(",").Select(int.Parse).ToArray();

                    foreach (var id in ActorIds)
                    {
                        await context.ActorMovies.AddAsync(new ActorMovie { ActorId = new_movie.Id, MovieId = id });
                    }

                    await context.SaveChangesAsync();
                }

                return Ok("New movie created successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a movie in database");
            }
        }


        [HttpPatch("{id:int}/edit")]
        public async Task<IActionResult> UpdateMoviePatch([FromRoute] int id, [FromBody] JsonPatchDocument<MoviePatchModel> patchModel)
        {
            try
            {
                var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if (movie == null)
                {
                    return NotFound("Couldn't find a movie with id: " + id);
                }

                patchModel.ApplyTo(movie, ModelState);

                await context.SaveChangesAsync();

                return Ok("The movie updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the actor");
            }
        }


        [HttpPut("{id:int}/profileImage/edit")]
        public async Task<IActionResult> UpdateImage([FromRoute] int id, [FromForm] UploadImageModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var movie = await context.Movies.FirstOrDefaultAsync(a => a.Id == id);

                if (movie == null)
                {
                    return NotFound("Couldn't find the movie with id: " + id);
                }

                string? movieImageName = movie.Image;

                if (movieImageName == null)
                {
                    movieImageName = CustomFunctions.GetUniqueFileName(10, Path.GetExtension(model.Image.FileName));
                }
                else
                {
                    fileOperations.DeleteFile(movieImageName, FileCategory.Image);
                }

                fileOperations.UploadFile(model.Image, movieImageName, FileCategory.Image);

                await context.SaveChangesAsync();

                return Ok(movieImageName);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the image");
            }
        }


        [HttpPut("{id:int}/video/edit")]
        public async Task<IActionResult> UpdateVideo([FromRoute] int id, [FromForm] UploadVideoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var movie = await context.Movies.FirstOrDefaultAsync(a => a.Id == id);

                if (movie == null)
                {
                    return NotFound("Couldn't find the movie with id: " + id);
                }

                string? movieVideoName = movie.Video;

                if (movieVideoName == null)
                {
                    movieVideoName = CustomFunctions.GetUniqueFileName(10, Path.GetExtension(model.VideoFile.FileName));
                }
                else
                {
                    fileOperations.DeleteFile(movieVideoName, FileCategory.Video);
                }

                fileOperations.UploadFile(model.VideoFile, movieVideoName, FileCategory.Video);

                await context.SaveChangesAsync();

                return Ok(movieVideoName);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the video");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            try
            {
                var movie = context.Movies.FirstOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    return NotFound();
                }

                fileOperations.DeleteFile(movie.Image, FileCategory.Image);
                fileOperations.DeleteFile(movie.Video, FileCategory.Video);

                context.Movies.Remove(movie);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(GetMovies));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting movies from the database");
            }
        }

    }
}
