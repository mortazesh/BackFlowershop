using FlowerShop.Application.Dto.Articles;
using FlowerShop.Domain.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Repository
{
    public interface IArticlesRepository
    {
        Task<ArticlesDto> Get(int Id);
        Task<IEnumerable<ArticlesDto>> GetAll();
        Task Add(AddArticlesDto articlesDto);
        Task<bool> Update(int Id,AddArticlesDto articlesDto);
        Task<bool> Delete(int Id);
        Task<Article> Find(int Id);
    }
}
