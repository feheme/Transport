using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Constants;
using Transport.Core.Utilities.Results;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.EntityFramework;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CommentDtos;
using Transport.Entities.DTOs.MessageDtos;

namespace Transport.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        ITeamRepository _teamRepository;
        IMessageRepository _messageRepository;

        public MessageManager(IUserRepository userRepository, IMapper mapper, ITeamRepository teamRepository, IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
            _messageRepository = messageRepository;
        }

        public async Task<IResult> AddAsync(MessageAddDto entity)
        {
            var newMessage = _mapper.Map<Message>(entity);
            newMessage.CreatedDate = DateTime.Now;
            await _messageRepository.AddAsync(newMessage);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _messageRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<MessageDetailDto>> GetAsync(Expression<Func<Message, bool>> filter)
        {
            var message = await _messageRepository.GetAsync(filter);
            if (message != null)
            {
                var messageDto = await AssignMessageDetails(message, message.TeamId, message.UserId);

                return new SuccessDataResult<MessageDetailDto>(messageDto, Messages.Listed);



            }
            return new ErrorDataResult<MessageDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<MessageDetailDto>> GetByIdAsync(int id)
        {
            var message = await _messageRepository.GetAsync(x => x.Id == id);
            if (message != null)
            {
                var messageDto = await AssignMessageDetails(message, message.TeamId, message.UserId);

                return new SuccessDataResult<MessageDetailDto>(messageDto, Messages.Listed);



            }
            return new ErrorDataResult<MessageDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<MessageDetailDto>>> GetListAsync(Expression<Func<Message, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _messageRepository.GetListAsync();
                var responseMessageDetailDto = _mapper.Map<IEnumerable<MessageDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<MessageDetailDto>>(responseMessageDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _messageRepository.GetListAsync(filter);
                var responseMessageDetailDto = _mapper.Map<IEnumerable<MessageDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<MessageDetailDto>>(responseMessageDetailDto, Messages.Listed);



            }
        }

        public async Task<IDataResult<MessageUpdateDto>> UpdateAsync(MessageUpdateDto messageUpdateDto)
        {
            var getMessage = await _messageRepository.GetAsync(x => x.Id == messageUpdateDto.Id);
            getMessage = _mapper.Map<Message>(messageUpdateDto);
            getMessage.UpdatedDate = DateTime.Now;
            getMessage.UpdatedBy = 1;

            var messageUpdate = await _messageRepository.UpdateAsync(getMessage);
            var resultUpdateDto = _mapper.Map<MessageUpdateDto>(messageUpdate);
            return new SuccessDataResult<MessageUpdateDto>(resultUpdateDto, Messages.Updated);
        }



        private async Task<MessageDetailDto> AssignMessageDetails(Message message, int teamId, int userId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);
            var user = await _userRepository.GetAsync(x => x.Id == userId);

            if (team == null || user == null)
            {
                return null;
            }

            message.Team = team;
            message.User = user;
            var messageDetail = _mapper.Map<MessageDetailDto>(message);
            return messageDetail;
        }
    }
}
