using AutoMapper;
using System.Linq.Expressions;
using Transport.Business.Abstract;
using Transport.Business.Constants;
using Transport.Core.Utilities.Results;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.EntityFramework;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.DriverDtos;
using Transport.Entities.DTOs.TeamDtos;

namespace Transport.Business.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamRepository _teamRepository;
        ICompanyRepository _companyRepository;
        IMapper _mapper;

        public TeamManager(ITeamRepository teamRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(TeamAddDto entity)
        {
            var newTeam = _mapper.Map<Team>(entity);
            newTeam.CreatedDate = DateTime.Now;
            await _teamRepository.AddAsync(newTeam);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _teamRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<TeamDetailDto>> GetAsync(Expression<Func<Team, bool>> filter)
        {
            var team = await _teamRepository.GetAsync(filter);
            if (team != null)
            {
                var teamDto = await AssignTeamDetails(team, team.CompanyId);
                return new SuccessDataResult<TeamDetailDto>(teamDto, Messages.Listed);

            }
            return new ErrorDataResult<TeamDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<TeamDetailDto>> GetByIdAsync(int id)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == id);
            if (team != null)
            {
                var teamDto = await AssignTeamDetails(team, team.CompanyId);
                return new SuccessDataResult<TeamDetailDto>(teamDto, Messages.Listed);

            }
            return new ErrorDataResult<TeamDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<TeamDetailDto>>> GetListAsync(Expression<Func<Team, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _teamRepository.GetListAsync();
                var responseTeamDetailDto = _mapper.Map<IEnumerable<TeamDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<TeamDetailDto>>(responseTeamDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _teamRepository.GetListAsync(filter);
                var responseTeamDetailDto = _mapper.Map<IEnumerable<TeamDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<TeamDetailDto>>(responseTeamDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<TeamUpdateDto>> UpdateAsync(TeamUpdateDto teamUpdateDto)
        {
            var getTeam = await _teamRepository.GetAsync(x => x.Id == teamUpdateDto.Id);

            getTeam = _mapper.Map<Team>(teamUpdateDto);


            getTeam.UpdatedDate = DateTime.Now;
            getTeam.UpdatedBy = 1;


            var teamUpdate = await _teamRepository.UpdateAsync(getTeam);
            var resultUpdateDto = _mapper.Map<TeamUpdateDto>(teamUpdate);

            return new SuccessDataResult<TeamUpdateDto>(resultUpdateDto, Messages.Updated);
        }


        private async Task<TeamDetailDto> AssignTeamDetails(Team team, int companyId)
        {
            var company = await _companyRepository.GetAsync(x => x.Id == companyId);

            if (company == null)
            {
                return null;
            }

            team.Company = company;

            var companyDetail = _mapper.Map<TeamDetailDto>(team);
            return companyDetail;
        }
    }
}
