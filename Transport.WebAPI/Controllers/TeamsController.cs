using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.TeamDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetTeamsById(int TeamId)
        {
            var result = await _teamService.GetByIdAsync(TeamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{companyId:int}")]
        public async Task<IActionResult> GetTeamsByTeamId(int companyId)
        {
            var result = await _teamService.GetListAsync(x => x.CompanyId == companyId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateTeam(TeamAddDto teamAddDto)
        {
            var result = await _teamService.AddAsync(teamAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var result = await _teamService.DeleteAsync(teamId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            var result = await _teamService.UpdateAsync(teamUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
