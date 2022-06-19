using FlowerShop.Application.Dto.Comment;
using FlowerShop.Application.Dto.Image;
using FlowerShop.Application.Dto.Property;
using FlowerShop.Application.Dto.Seos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Dto.Product
{
    public class ProductDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { get; set; }
        public int Price { set; get; }
        public DateTime Created { set; get; }
        public int Count { set; get; }
        public bool Exsit { set; get; }
        public string NameShop { get; set; }
        public List<CommentDto> comment { get; set; }
        public SeoDto seos { get; set; }
        public List<PropertyDto> property { get; set; }
        public List<ImageDto> image { get; set; }
    }
}
