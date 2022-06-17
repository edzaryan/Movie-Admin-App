using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Custom;
using Movie_Admin_App.Custom_Functionalities;
using Movie_Admin_App.CustomModels;
using Movie_Admin_App.Data;
using Movie_Admin_App.Data.enums;
using Movie_Admin_App.Models;
using Movie_Admin_App.ViewModels;
using MovieWebAppAdmin.ViewModels;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IFileOperations fileOperations;

        public MovieController(ApplicationContext context, IFileOperations fileOperations)
        {
            this.context = context;
            this.fileOperations = fileOperations;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetMovies([FromQuery] int page = 1)
        {
            try
            {
                //var movies = await context.Movies
                //    .Skip(page == 1 ? 0 : page * 16 - 16)
                //    .Take(16)
                //    .Select(m => new
                //    {
                //        //m.Id,
                //        //m.Title,
                //        //ActorList = m.Actors.Select(a => new
                //        //{
                //        //    a.Id,
                //        //    a.FirstName,
                //        //}),
                //        m.Genres,
                //        m.Countries
                //    })
                //    .ToListAsync();

                return Ok();
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
                int[] durBounds = model.dur.Split('-').Select(int.Parse).ToArray();
                int[] popBounds = model.pop.Split('-').Select(int.Parse).ToArray();
                int[] yearBounds = model.year.Split('-').Select(int.Parse).ToArray();
                double[] ratBounds = model.rat.Split('-').Select(double.Parse).ToArray();
                string[] countList = model.count.Split(',').ToArray();

                //var movies = await context.Movies.Select(m => new
                //{
                //    m.Id,
                //    m.Title,
                //    m.Genres
                //}).ToListAsync();

                //Console.WriteLine(durBounds[0] + " " + durBounds[1]);
                //Console.WriteLine(popBounds[0] + " " + durBounds[1]);
                //Console.WriteLine(yearBounds[0] + " " + yearBounds[1]);
                //Console.WriteLine(ratBounds[0] + " " + ratBounds[1]);
                //Console.WriteLine(countList[0] + " " + countList[1]);

                //var movies = await context.Movies.Where(m =>
                //                    m.Title.Contains(model.v))
                //                    //m.Year >= yearBounds[0] && m.Year <= yearBounds[1])
                //                    //m.Countries.Any(c => countList.Contains(c.Name)))
                //                    //m.Duration >= ratBounds[0] && m.Duration <= ratBounds[1])
                //                    .Select(m => new
                //                    {
                //                        m.Id,
                //                        m.Title,
                //                        m.Countries,
                //                        m.Genres,
                //                        m.Actors
                //                    })
                //                    .ToListAsync();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting movies from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            try
            {
                var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

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
        public async Task<IActionResult> CreateMovie([FromForm] CreateMovieModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            string uniquImageFileName = fileOperations.UploadFile(model.UploadedImage, FileCategory.Image);

            string uniqueVideoFileName = fileOperations.UploadFile(model.UploadedVideo, FileCategory.Video);

            int videoFileDuration = fileOperations.GetVideoFileDuration(uniqueVideoFileName);

            var new_movie = new Movie
            {
                Title = model.Title,
                Year = model.Year,
                Description = model.Description,
                Duration = videoFileDuration,
                Image = uniquImageFileName,
                VideoFileName = uniqueVideoFileName,
            };

            await context.Movies.AddAsync(new_movie);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(GetMovies));
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromForm] UpdateMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound("There is not a movie with id: " + id);
            }

            if (model.UploadedImage != null)
            {
                fileOperations.DeleteFile(movie.Image, FileCategory.Image);
                movie.Image = fileOperations.UploadFile(model.UploadedImage, FileCategory.Image);
            }

            if (model.UploadedVideo != null)
            {
                fileOperations.DeleteFile(movie.VideoFileName, FileCategory.Video);
                movie.VideoFileName = fileOperations.UploadFile(model.UploadedVideo, FileCategory.Video);

                movie.Duration = fileOperations.GetVideoFileDuration(movie.VideoFileName);
            }

            if (model.Title != null)
            {
                movie.Title = model.Title;
            }

            if (model.Year != null)
            {
                movie.Year = model.Year;
            }

            if (model.Description != null)
            {
                movie.Description = model.Description;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(GetMovieById), new { Id = movie.Id });
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
                fileOperations.DeleteFile(movie.VideoFileName, FileCategory.Video);

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
