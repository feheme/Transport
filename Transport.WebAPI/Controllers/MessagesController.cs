using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Entities.DTOs.MessageDtos;

namespace Transport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetMessages()
        {
            var result = await _messageService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{messageId:int}")]
        public async Task<IActionResult> GetMessagesById(int MessageId)
        {
            var result = await _messageService.GetByIdAsync(MessageId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{teamId:int}")]
        public async Task<IActionResult> GetMessagesByTeamId(int teamId)
        {
            var result = await _messageService.GetListAsync(x => x.TeamId == teamId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{userId:int}")]
        public async Task<IActionResult> GetMessagesByUserId(int userId)
        {
            var result = await _messageService.GetListAsync(x => x.UserId == userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateMessage(MessageAddDto messageAddDto)
        {
            var result = await _messageService.AddAsync(messageAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{messageId:int}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var result = await _messageService.DeleteAsync(messageId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateMessage(MessageUpdateDto messageUpdateDto)
        {
            var result = await _messageService.UpdateAsync(messageUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
