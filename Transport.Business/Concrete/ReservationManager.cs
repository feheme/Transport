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
using Transport.Entities.DTOs.MessageDtos;
using Transport.Entities.DTOs.ReservationDtos;

namespace Transport.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IUserRepository _userRepository;
        ITeamRepository _teamRepository;
        IReservationRepository _reservationRepository;
        IMapper _mapper;
        public async Task<IResult> AddAsync(ReservationAddDto entity)
        {
            var newReservation = _mapper.Map<Reservation>(entity);
            newReservation.CreatedDate = DateTime.Now;
            await _reservationRepository.AddAsync(newReservation);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _reservationRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<ReservationDetailDto>> GetAsync(Expression<Func<Reservation, bool>> filter)
        {
            var reservation = await _reservationRepository.GetAsync(filter);
            if (reservation != null)
            {
                var reservationDto = await AssignReservationDetails(reservation, reservation.TeamId, reservation.UserId);

                return new SuccessDataResult<ReservationDetailDto>(reservationDto, Messages.Listed);



            }
            return new ErrorDataResult<ReservationDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<ReservationDetailDto>> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetAsync(x => x.Id == id);
            if (reservation != null)
            {
                var reservationDto = await AssignReservationDetails(reservation, reservation.TeamId, reservation.UserId);

                return new SuccessDataResult<ReservationDetailDto>(reservationDto, Messages.Listed);



            }
            return new ErrorDataResult<ReservationDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<ReservationDetailDto>>> GetListAsync(Expression<Func<Reservation, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _reservationRepository.GetListAsync();
                var responseReservationDetailDto = _mapper.Map<IEnumerable<ReservationDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ReservationDetailDto>>(responseReservationDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _reservationRepository.GetListAsync(filter);
                var responseReservationDetailDto = _mapper.Map<IEnumerable<ReservationDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<ReservationDetailDto>>(responseReservationDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<ReservationUpdateDto>> UpdateAsync(ReservationUpdateDto reservationUpdateDto)
        {
            var getReservation = await _reservationRepository.GetAsync(x => x.Id == reservationUpdateDto.Id);
            getReservation = _mapper.Map<Reservation>(reservationUpdateDto);
            getReservation.UpdatedDate = DateTime.Now;
            getReservation.UpdatedBy = 1;

            var reservationUpdate = await _reservationRepository.UpdateAsync(getReservation);
            var resultUpdateDto = _mapper.Map<ReservationUpdateDto>(reservationUpdate);
            return new SuccessDataResult<ReservationUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        private async Task<ReservationDetailDto> AssignReservationDetails(Reservation reservation, int teamId, int userId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);
            var user = await _userRepository.GetAsync(x => x.Id == userId);

            if (team == null || user == null)
            {
                return null;
            }

            reservation.Team = team;
            reservation.User = user;
            var reservationDetail = _mapper.Map<ReservationDetailDto>(reservation);
            return reservationDetail;
        }

    }
}
