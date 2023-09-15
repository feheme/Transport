using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Utilities.Results;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.MessageDtos;

namespace Transport.Business.Abstract
{
    public interface IMessageService
    {
        Task<IResult> AddAsync(MessageAddDto entity);

        Task<IDataResult<IEnumerable<MessageDetailDto>>> GetListAsync(Expression<Func<Message, bool>> filter = null);
        Task<IDataResult<MessageDetailDto>> GetAsync(Expression<Func<Message, bool>> filter);

        Task<IDataResult<MessageDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<MessageUpdateDto>> UpdateAsync(MessageUpdateDto messageUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
