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
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CommentDtos;

namespace Transport.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        IUserRepository _userRepository;
        ITeamRepository _teamRepository;
        ICommentRepository _commentRepository;
        IMapper _mapper;

        public CommentManager(IUserRepository userRepository, ITeamRepository teamRepository, IMapper mapper, ICommentRepository commentRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<IResult> AddAsync(CommentAddDto entity)
        {
            var newComment = _mapper.Map<Comment>(entity);
            newComment.CreatedDate = DateTime.Now;
            await _commentRepository.AddAsync(newComment);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _commentRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CommentDetailDto>> GetAsync(Expression<Func<Comment, bool>> filter)
        {
            var comment = await _commentRepository.GetAsync(filter);
            if (comment != null)
            {
                var commentDto = await AssignCommentDetails(comment, comment.TeamId, comment.UserId);

                return new SuccessDataResult<CommentDetailDto>(commentDto, Messages.Listed);



            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CommentDetailDto>> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetAsync(x => x.Id == id);
            if (comment != null)
            {
                var commentDto = await AssignCommentDetails(comment, comment.TeamId, comment.UserId);

                return new SuccessDataResult<CommentDetailDto>(commentDto, Messages.Listed);



            }
            return new ErrorDataResult<CommentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CommentDetailDto>>> GetListAsync(Expression<Func<Comment, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _commentRepository.GetListAsync();
                var responseCommentDetailDto = _mapper.Map<IEnumerable<CommentDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentDetailDto>>(responseCommentDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _commentRepository.GetListAsync(filter);
                var responseCommentDetailDto = _mapper.Map<IEnumerable<CommentDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CommentDetailDto>>(responseCommentDetailDto, Messages.Listed);



            }
        }

        public async Task<IDataResult<CommentUpdateDto>> UpdateAsync(CommentUpdateDto commentUpdateDto)
        {
            var getComment = await _commentRepository.GetAsync(x => x.Id == commentUpdateDto.Id);
            getComment = _mapper.Map<Comment>(commentUpdateDto);
            getComment.UpdatedDate = DateTime.Now; 
            getComment.UpdatedBy = 1;

            var commentUpdate = await _commentRepository.UpdateAsync(getComment);
            var resultUpdateDto = _mapper.Map<CommentUpdateDto>(commentUpdate);
            return new SuccessDataResult<CommentUpdateDto>(resultUpdateDto, Messages.Updated);
        }




        private async Task<CommentDetailDto> AssignCommentDetails(Comment comment, int teamId, int userId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);
            var user = await _userRepository.GetAsync(x => x.Id == userId);

            if (team == null || user == null)
            {
                return null;
            }

            comment.Team = team;
            comment.User = user;
            var commentDetail = _mapper.Map<CommentDetailDto>(comment);
            return commentDetail;
        }
    }
}
