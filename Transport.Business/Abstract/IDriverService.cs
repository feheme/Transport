using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.DriverDtos;

namespace Transport.Business.Abstract
{
    public interface IDriverService
    {
        Task<IResult> AddAsync(DriverAddDto entity);


        Task<IDataResult<IEnumerable<DriverDetailDto>>> GetListAsync(Expression<Func<Driver, bool>> filter = null);
        Task<IDataResult<DriverDetailDto>> GetAsync(Expression<Func<Driver, bool>> filter);

        Task<IDataResult<DriverDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<DriverUpdateDto>> UpdateAsync(DriverUpdateDto driverUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
