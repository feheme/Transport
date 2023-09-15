using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.VehicleDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetVehicles()
        {
            var result = await _vehicleService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{vehicleId:int}")]
        public async Task<IActionResult> GetVehiclesById(int VehicleId)
        {
            var result = await _vehicleService.GetByIdAsync(VehicleId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetVehiclesByTeamId(int teamId)
        {
            var result = await _vehicleService.GetListAsync(x => x.TeamId == teamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateVehicle(VehicleAddDto vehicleAddDto)
        {
            var result = await _vehicleService.AddAsync(vehicleAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{vehicleId:int}")]
        public async Task<IActionResult> DeleteVehicle(int vehicleId)
        {
            var result = await _vehicleService.DeleteAsync(vehicleId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateVehicle(VehicleUpdateDto vehicleUpdateDto)
        {
            var result = await _vehicleService.UpdateAsync(vehicleUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
