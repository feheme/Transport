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
using Transport.Entities.DTOs.DriverDtos;

namespace Transport.Business.Concrete
{
    public class DriverManager : IDriverService
    {
        IDriverRepository _driverRepository;
        ITeamRepository _teamRepository;
        IMapper _mapper;

        public DriverManager(IDriverRepository driverRepository, ITeamRepository teamRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(DriverAddDto entity)
        {
            var newDriver = _mapper.Map<Driver>(entity);
            newDriver.CreatedDate = DateTime.Now;
            await _driverRepository.AddAsync(newDriver);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _driverRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<DriverDetailDto>> GetAsync(Expression<Func<Driver, bool>> filter)
        {
            var driver = await _driverRepository.GetAsync(filter);
            if (driver != null)
            {
                var driverDto = await AssignDriverDetails(driver, driver.TeamId);
                return new SuccessDataResult<DriverDetailDto>(driverDto, Messages.Listed);

            }
            return new ErrorDataResult<DriverDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<DriverDetailDto>> GetByIdAsync(int id)
        {
            var driver = await _driverRepository.GetAsync(x => x.Id == id);
            if (driver != null)
            {
                var driverDto = await AssignDriverDetails(driver, driver.TeamId);
                return new SuccessDataResult<DriverDetailDto>(driverDto, Messages.Listed);

            }
            return new ErrorDataResult<DriverDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<DriverDetailDto>>> GetListAsync(Expression<Func<Driver, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _driverRepository.GetListAsync();
                var responseDriverDetailDto = _mapper.Map<IEnumerable<DriverDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<DriverDetailDto>>(responseDriverDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _driverRepository.GetListAsync(filter);
                var responseDriverDetailDto = _mapper.Map<IEnumerable<DriverDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<DriverDetailDto>>(responseDriverDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<DriverUpdateDto>> UpdateAsync(DriverUpdateDto driverUpdateDto)
        {
            var getDriver = await _driverRepository.GetAsync(x => x.Id == driverUpdateDto.Id);

            getDriver = _mapper.Map<Driver>(driverUpdateDto);


            getDriver.UpdatedDate = DateTime.Now;
            


            var driverUpdate = await _driverRepository.UpdateAsync(getDriver);
            var resultUpdateDto = _mapper.Map<DriverUpdateDto>(driverUpdate);

            return new SuccessDataResult<DriverUpdateDto>(resultUpdateDto, Messages.Updated);
        }

        private async Task<DriverDetailDto> AssignDriverDetails(Driver driver, int teamId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);

            if (team == null)
            {
                return null;
            }

            driver.Team = team;

            var driverDetail = _mapper.Map<DriverDetailDto>(driver);
            return driverDetail;
        }
    }
}
