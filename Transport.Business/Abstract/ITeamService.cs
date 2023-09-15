using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.TeamDtos;

namespace Transport.Business.Abstract
{
    public interface ITeamService
    {
        Task<IResult> AddAsync(TeamAddDto entity);


        Task<IDataResult<IEnumerable<TeamDetailDto>>> GetListAsync(Expression<Func<Team, bool>> filter = null);
        Task<IDataResult<TeamDetailDto>> GetAsync(Expression<Func<Team, bool>> filter);

        Task<IDataResult<TeamDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<TeamUpdateDto>> UpdateAsync(TeamUpdateDto teamUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
