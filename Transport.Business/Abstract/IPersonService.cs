
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.PersonDtos;

namespace Transport.Business.Abstract
{
    public interface IPersonService
    {
        Task<IResult> AddAsync(PersonAddDto entity);


        Task<IDataResult<IEnumerable<PersonDetailDto>>> GetListAsync(Expression<Func<Person, bool>> filter = null);
        Task<IDataResult<PersonDetailDto>> GetAsync(Expression<Func<Person, bool>> filter);

        Task<IDataResult<PersonDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<PersonUpdateDto>> UpdateAsync(PersonUpdateDto personUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
