using AutoMapper;
using FlowerShop.Application.Dto.Comment;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Service
{
    public class CommentService: ICommentRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public CommentService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddCommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            var comments = await _context.Comments
                .Select(c => new CommentDto
                {
                    Created = c.Created,
                    Description = c.Description,
                    UserName = c.Users.UserName
                })
                .ToListAsync();
            return comments;
        }
    }
}
