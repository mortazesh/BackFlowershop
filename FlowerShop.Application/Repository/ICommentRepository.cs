using FlowerShop.Application.Dto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<CommentDto>> GetAll();
        Task Add(AddCommentDto commentDto);
    }
}
