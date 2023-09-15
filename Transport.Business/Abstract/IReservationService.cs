using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.ReservationDtos;

namespace Transport.Business.Abstract
{
    public interface IReservationService
    {
        Task<IResult> AddAsync(ReservationAddDto entity);


        Task<IDataResult<IEnumerable<ReservationDetailDto>>> GetListAsync(Expression<Func<Reservation, bool>> filter = null);
        Task<IDataResult<ReservationDetailDto>> GetAsync(Expression<Func<Reservation, bool>> filter);

        Task<IDataResult<ReservationDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<ReservationUpdateDto>> UpdateAsync(ReservationUpdateDto reservationUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
