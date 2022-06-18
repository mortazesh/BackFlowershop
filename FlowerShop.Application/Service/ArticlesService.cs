using AutoMapper;
using FlowerShop.Application.Dto.Articles;
using FlowerShop.Application.Dto.Comment;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Service
{
    public class ArticlesService: IArticlesRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public ArticlesService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddArticlesDto articlesDto)
        {
            var articles = _mapper.Map<Article>(articlesDto);
            await _context.Articles.AddAsync(articles);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int Id)
        {
            var article = await Find(Id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Article> Find(int Id)
        {
            var article = await _context.Articles.FindAsync(Id);
            return article != null ? article : null;
        }

        public async Task<ArticlesDto> Get(int Id)
        {
            var article = await _context.Articles
                .Where(a => a.Id == Id)
                .Include(a => a.Comment)
                .Include(a => a.Seos)
                .FirstOrDefaultAsync();
            return new ArticlesDto
            {
                Id = article.Id,
                Author = article.Author,
                Description = article.Description,
                Title = article.Title,
                UrlImage = article.UrlImage,
                seoDto = new Dto.Seos.SeoDto
                {
                    Created = article.Seos.Created,
                    Description = article.Seos.Description
                },
                commentDto = article.Comment.Select(comment => new CommentDto
                {
                    Created = comment.Created,
                    Description= comment.Description,
                    UserName = comment.Users.UserName
                }).ToList()
            };
        }

        public async Task<IEnumerable<ArticlesDto>> GetAll()
        {
            var article = await _context.Articles
                .Select(a => new ArticlesDto
                {
                    Title = a.Title,
                    Description = a.Description
                }).ToListAsync();
            return article;
        }

        public async Task<bool> Update(AddArticlesDto articlesDto)
        {
            var article = await Find(articlesDto.Id);
            if (article != null)
            {
                var articles = _mapper.Map(articlesDto, article);
                _context.Articles.Update(articles);
                await _context.SaveChangesAsync();
                return false;
            }
            return false;
        }
    }
}
