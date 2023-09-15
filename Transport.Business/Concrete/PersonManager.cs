using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Constants;
using Transport.Core.Utilities.Messages;
using Transport.Core.Utilities.Results;
using Transport.DataAccess.Abstract;
using Transport.DataAccess.Concrete.EntityFramework;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.DriverDtos;
using Transport.Entities.DTOs.PersonDtos;

namespace Transport.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        ITeamRepository _teamRepository;
        IMapper _mapper;
        IPersonRepository _personRepository;

        public PersonManager(ITeamRepository teamRepository, IMapper mapper, IPersonRepository personRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<IResult> AddAsync(PersonAddDto entity)
        {
            var newPerson = _mapper.Map<Person>(entity);
            newPerson.CreatedDate = DateTime.Now;
            await _personRepository.AddAsync(newPerson);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _personRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<PersonDetailDto>> GetAsync(Expression<Func<Person, bool>> filter)
        {
            var person = await _personRepository.GetAsync(filter);
            if (person != null)
            {
                var personDto = await AssignPersonDetails(person, person.TeamId);
                return new SuccessDataResult<PersonDetailDto>(personDto, Messages.Listed);

            }
            return new ErrorDataResult<PersonDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<PersonDetailDto>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetAsync(x => x.Id == id);
            if (person != null)
            {
                var personDto = await AssignPersonDetails(person, person.TeamId);
                return new SuccessDataResult<PersonDetailDto>(personDto, Messages.Listed);

            }
            return new ErrorDataResult<PersonDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<PersonDetailDto>>> GetListAsync(Expression<Func<Person, bool>> filter = null)
        {
            if (filter == null)
            {

                var response = await _personRepository.GetListAsync();
                var responsePersonDetailDto = _mapper.Map<IEnumerable<PersonDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<PersonDetailDto>>(responsePersonDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _personRepository.GetListAsync(filter);
                var responsePersonDetailDto = _mapper.Map<IEnumerable<PersonDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<PersonDetailDto>>(responsePersonDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<PersonUpdateDto>> UpdateAsync(PersonUpdateDto personUpdateDto)
        {
            var getPerson = await _personRepository.GetAsync(x => x.Id == personUpdateDto.Id);

            getPerson = _mapper.Map<Person>(personUpdateDto);


            getPerson.UpdatedDate = DateTime.Now;
            getPerson.UpdatedBy = 1;


            var personUpdate = await _personRepository.UpdateAsync(getPerson);
            var resultUpdateDto = _mapper.Map<PersonUpdateDto>(personUpdate);

            return new SuccessDataResult<PersonUpdateDto>(resultUpdateDto, Messages.Updated);
        }



        private async Task<PersonDetailDto> AssignPersonDetails(Person person, int teamId)
        {
            var team = await _teamRepository.GetAsync(x => x.Id == teamId);

            if (team == null)
            {
                return null;
            }

            person.Team = team;

            var PersonDetail = _mapper.Map<PersonDetailDto>(person);
            return PersonDetail;
        }

    }
}
