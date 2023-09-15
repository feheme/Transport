using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.UserOperationClaimDtos
{
    public class UserOperationClaimDetailDto : IDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public int OperationClaimId { get; set; }
        public string RoleName { get; set; }
    }
}
