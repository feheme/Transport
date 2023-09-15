using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.DriverDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        IDriverService _driverService;
        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetDrivers()
        {
            var result = await _driverService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{driverId:int}")]
        public async Task<IActionResult> GetDriversById(int DriverId)
        {
            var result = await _driverService.GetByIdAsync(DriverId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetDriversByTeamId(int teamId)
        {
            var result = await _driverService.GetListAsync(x => x.TeamId == teamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateDriver(DriverAddDto driverAddDto)
        {
            var result = await _driverService.AddAsync(driverAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{driverId:int}")]
        public async Task<IActionResult> DeleteDriver(int driverId)
        {
            var result = await _driverService.DeleteAsync(driverId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateDriver(DriverUpdateDto driverUpdateDto)
        {
            var result = await _driverService.UpdateAsync(driverUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
