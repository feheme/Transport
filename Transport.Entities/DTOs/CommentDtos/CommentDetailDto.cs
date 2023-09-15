using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.CommentDtos
{
    public class CommentDetailDto : IDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
