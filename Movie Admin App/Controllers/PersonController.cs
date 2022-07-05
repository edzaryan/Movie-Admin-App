using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Movie_Admin_App.IServices;
using Movie_Admin_App.Models;
using Movie_Admin_App.Models.PersonModels;
using Movie_Admin_App.Services;

namespace Movie_Admin_App.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IGenericPersonService<Actor> _repository;

        public PersonController(IGenericPersonService<Actor> repository) => _repository = repository;


        [HttpGet("")]
        public async Task<IActionResult> GetActorsByAlphabet([FromQuery] string ch = "A", [FromQuery] int page = 1)
        {
            try
            {
                var actors = _repository.FindAllByAlphabet(ch, page).Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                });

                return Ok(actors);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving genres from the database");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetActorsBySearch([FromQuery] string v = "", [FromQuery] int page = 1)
        {
            try
            {
                var actors = _repository.FindAllBySearch(v, page).Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName
                });

                return Ok(actors);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving actors from the database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetActorById([FromRoute] int id)
        {
            try
            {
                var actor = _repository.GetById(id)
                                .Select(a => new
                                {
                                    a.Id,
                                    a.FirstName,
                                    a.LastName,
                                    a.Bio,
                                    a.Birthday,
                                    a.Height,
                                    a.Image,
                                    Country = new { a.Country.Id, a.Country.Name },
                                    Movies = a.ActorMovies.Select(am => new
                                    {
                                        am.Movie.Title,
                                        am.Movie.Year,
                                        am.Movie.Image
                                    })
                                }).FirstOrDefault();

                return Ok(actor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving the actor from the database");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateActor([FromForm] PersonCreateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var new_actor = new Actor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Bio = model.Bio,
                    Birthday = model.Birthday,
                    CountryId = model.CountryId,
                    Height = model.Height,
                };

                _repository.Add(new_actor);

                _repository.SaveChanges();

                return Ok("New actor created successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while creating an actor in database");
            }
        }


        [HttpPatch("{id:int}/edit")]
        public async Task<IActionResult> UpdateActorPatch([FromRoute] int id, [FromBody] JsonPatchDocument<PersonPatchModel> patchModel)
        {
            try
            {
                var actor = (Actor)_repository.GetById(id);

                patchModel.ApplyTo(actor, ModelState);

                _repository.SaveChanges();

                return Ok("The actor updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the actor");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteActor([FromRoute] int id)
        {
            try
            {
                var actor = (Actor)_repository.GetById(id);

                _repository.Delete(actor);

                _repository.SaveChanges();

                return Ok("The actor successfully deleted!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while deleting the actor");
            }
        }


        [HttpPut("{id:int}/image/edit")]
        public async Task<IActionResult> UpdateImage([FromRoute] int id, [FromForm] UploadImageModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var actor = (Actor)_repository.GetById(id);

                _repository.UpdateImage(actor, model.Image);

                _repository.SaveChanges();

                return Ok("Actor image updated successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error occured while updating the image");
            }
        }

    }

}
