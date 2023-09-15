using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.ReservationDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationService _reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetReservations()
        {
            var result = await _reservationService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{reservationId:int}")]
        public async Task<IActionResult> GetReservationsById(int ReservationId)
        {
            var result = await _reservationService.GetByIdAsync(ReservationId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetReservationsByTeamId(int teamId)
        {
            var result = await _reservationService.GetListAsync(x => x.TeamId == teamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{userId:int}")]
        public async Task<IActionResult> GetReservationsByUserId(int userId)
        {
            var result = await _reservationService.GetListAsync(x => x.UserId == userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateReservation(ReservationAddDto reservationAddDto)
        {
            var result = await _reservationService.AddAsync(reservationAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{reservationId:int}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var result = await _reservationService.DeleteAsync(reservationId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateReservation(ReservationUpdateDto reservationUpdateDto)
        {
            var result = await _reservationService.UpdateAsync(reservationUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
