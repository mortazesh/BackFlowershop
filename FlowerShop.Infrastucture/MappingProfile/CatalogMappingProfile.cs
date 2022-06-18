using AutoMapper;
using FlowerShop.Application.Dto.Articles;
using FlowerShop.Domain.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Infrastucture.MappingProfile
{
    internal class CatalogMappingProfile: Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<Article, ArticlesDto>().ReverseMap();
        }
    }
}
