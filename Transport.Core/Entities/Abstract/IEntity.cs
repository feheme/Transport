using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Core.Entities.Abstract
{
    /// <summary>
    /// Veri tabanında karşılık gelen tablolarda  olacak 
    /// </summary>
    public interface IEntity
    {

        public int Id { get; set; }


    }
}
