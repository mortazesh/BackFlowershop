using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Dto.Comment
{
    public class AddCommentDto
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
