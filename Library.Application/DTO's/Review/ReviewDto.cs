using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTO_s.Review
{
    public class ReviewDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
        public Guid? BookId { get; set; }

    }
}
