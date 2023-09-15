using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Abstract;

namespace Transport.Entities.DTOs.CommentDtos
{
    public class CommentAddDto : IDto
    {
        public string Content { get; set; }

        public int TeamId { get; set; }

        public int UserId { get; set; }
    }
}
