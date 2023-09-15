using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.PersonDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPersons()
        {
            var result = await _personService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{personId:int}")]
        public async Task<IActionResult> GetPersonsById(int PersonId)
        {
            var result = await _personService.GetByIdAsync(PersonId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetPersonsByTeamId(int teamId)
        {
            var result = await _personService.GetListAsync(x => x.TeamId == teamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreatePerson(PersonAddDto personAddDto)
        {
            var result = await _personService.AddAsync(personAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{personId:int}")]
        public async Task<IActionResult> DeletePerson(int personId)
        {
            var result = await _personService.DeleteAsync(personId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdatePerson(PersonUpdateDto personUpdateDto)
        {
            var result = await _personService.UpdateAsync(personUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
