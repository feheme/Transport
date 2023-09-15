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
using Transport.Entities.DTOs.DriverDtos;
using Transport.Entities.DTOs.VehicleDtos;

namespace Transport.Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleRepository _vehicleRepository;
        ITeamRepository _teamRepository;
        IMapper _mapper;

        public VehicleManager(IVehicleRepository vehicleRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(VehicleAddDto entity)
        {
            var newVehicle = _mapper.Map<Vehicle>(entity);
            newVehicle.CreatedDate = DateTime.Now;
            await _vehicleRepository.AddAsync(newVehicle);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _vehicleRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<VehicleDetailDto>> GetAsync(Expression<Func<Vehicle, bool>> filter)
        {
            var vehicle = await _vehicleRepository.GetAsync(filter);
            if (vehicle != null)
            {
                var vehicleDto = await AssignVehicleDetails(vehicle, vehicle.TeamId);
                return new SuccessDataResult<VehicleDetailDto>(vehicleDto, Messages.Listed);

            }
            return new ErrorDataResult<VehicleDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<VehicleDetailDto>> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetAsync(x => x.Id == id);
            if (vehicle != null)
            {
                var vehicleDto = await AssignVehicleDetails(vehicle, vehicle.TeamId);
                return new SuccessDataResult<VehicleDetailDto>(vehicleDto, Messages.Listed);

            }
            return new ErrorDataResult<VehicleDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<VehicleDetailDto>>> GetListAsync(Expression<Func<Vehicle, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _vehicleRepository.GetListAsync();
                var responseVehicleDetailDto = _mapper.Map<IEnumerable<VehicleDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<VehicleDetailDto>>(responseVehicleDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _vehicleRepository.GetListAsync(filter);
                var responseVehicleDetailDto = _mapper.Map<IEnumerable<VehicleDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<VehicleDetailDto>>(responseVehicleDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<VehicleUpdateDto>> UpdateAsync(VehicleUpdateDto vehicleUpdateDto)
        {
            var getVehicle = await _vehicleRepository.GetAsync(x => x.Id == vehicleUpdateDto.Id);

            getVehicle = _mapper.Map<Vehicle>(vehicleUpdateDto);


            getVehicle.UpdatedDate = DateTime.Now;
           


            var vehicleUpdate = await _vehicleRepository.UpdateAsync(getVehicle);
            var resultUpdateDto = _mapper.Map<VehicleUpdateDto>(vehicleUpdate);

            return new SuccessDataResult<VehicleUpdateDto>(resultUpdateDto, Messages.Updated);
        }

        private async Task<VehicleDetailDto> AssignVehicleDetails(Vehicle vehicle, int teamId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);

            if (team == null)
            {
                return null;
            }

            vehicle.Team = team;

            var vehicleDetail = _mapper.Map<VehicleDetailDto>(vehicle);
            return vehicleDetail;
        }
    }
}
