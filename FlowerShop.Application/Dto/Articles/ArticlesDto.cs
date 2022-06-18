using FlowerShop.Application.Dto.Comment;
using FlowerShop.Application.Dto.Seos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Dto.Articles
{
    public class ArticlesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string UrlImage { get; set; }
        public SeoDto seoDto { get; set; }
        public List<CommentDto> commentDto { get; set; }
    }
}
