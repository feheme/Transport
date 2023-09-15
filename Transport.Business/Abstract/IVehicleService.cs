using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.VehicleDtos;

namespace Transport.Business.Abstract
{
    public interface IVehicleService
    {
        Task<IResult> AddAsync(VehicleAddDto entity);


        Task<IDataResult<IEnumerable<VehicleDetailDto>>> GetListAsync(Expression<Func<Vehicle, bool>> filter = null);
        Task<IDataResult<VehicleDetailDto>> GetAsync(Expression<Func<Vehicle, bool>> filter);

        Task<IDataResult<VehicleDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<VehicleUpdateDto>> UpdateAsync(VehicleUpdateDto vehicleUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
