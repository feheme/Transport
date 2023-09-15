using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Constants;
using Transport.Core.Utilities.Messages;
using Transport.Core.Utilities.Results;
using Transport.DataAccess.Abstract;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CompanyDtos;

namespace Transport.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {

        ICompanyRepository _companyRepository;
        IMapper _mapper;

        public CompanyManager(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(CompanyAddDto entity)
        {
            var newCompany = _mapper.Map<Company>(entity);
            await _companyRepository.AddAsync(newCompany);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _companyRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetAsync(Expression<Func<Company, bool>> filter)
        {
            var company = await _companyRepository.GetAsync(filter);
            if (company != null)
            {

                var companyDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDto, Messages.Listed);
            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<CompanyDetailDto>> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetAsync(x => x.Id == id);
            if (company != null)
            {

                var companyDto = _mapper.Map<CompanyDetailDto>(company);
                return new SuccessDataResult<CompanyDetailDto>(companyDto, Messages.Listed);
            }
            return new ErrorDataResult<CompanyDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<CompanyDetailDto>>> GetListAsync(Expression<Func<Company, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _companyRepository.GetListAsync();
                var responseCompanyDetailDto = _mapper.Map<IEnumerable<CompanyDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CompanyDetailDto>>(responseCompanyDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _companyRepository.GetListAsync(filter);
                var responseCompanyDetailDto = _mapper.Map<IEnumerable<CompanyDetailDto>>(response);
                return new SuccessDataResult<IEnumerable<CompanyDetailDto>>(responseCompanyDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<CompanyUpdateDto>> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            var getCompany = await _companyRepository.GetAsync(x => x.Id == companyUpdateDto.Id);
            getCompany = _mapper.Map<Company>(companyUpdateDto);
            getCompany.UpdatedDate = DateTime.Now;
            

            var companyUpdate = await _companyRepository.UpdateAsync(getCompany);
            var resultUpdateDto = _mapper.Map<CompanyUpdateDto>(companyUpdate);

            return new SuccessDataResult<CompanyUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
