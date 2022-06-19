using AutoMapper;
using FlowerShop.Application.Dto.Product;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Service
{
    public class ProductService: IProductRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public ProductService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int Id)
        {
            var product = await Find(Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Product> Find(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            return product != null ? product : null;
        }

        public async Task<ProductDto> Get(int Id)
        {
            var product = await _context.Products
                .Where(p => p.Id == Id)
                .Include(p => p.Images)
                .Include(p => p.Properties)
                .Include(p => p.Seos)
                .Include(p => p.Comments)
                .Include(p => p.Shop)
                .FirstOrDefaultAsync();
            return new ProductDto
            {
                Id = product.Id,
                Count = product.Count,
                Created = product.Created,
                Description = product.Description,
                Exsit = product.Exsit,
                Name = product.Name,
                Price = product.Price,
                NameShop = product.Shop.Name,
                comment = product.Comments.Select(p => new Dto.Comment.CommentDto
                {
                    UserName = p.Users.UserName,
                    Created = p.Created,
                    Description = p.Description
                }).ToList(),
                image = product.Images.Select(p => new Dto.Image.ImageDto
                {
                    UrlImage = p.UrlImage
                }).ToList(),
                property = product.Properties.Select(p => new Dto.Property.PropertyDto
                {
                    Name = p.Name,
                    Value = p.Value
                }).ToList(),
                seos = new Dto.Seos.SeoDto
                {
                    Created = product.Seos.Created,
                    Description = product.Seos.Description
                }
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var product = await _context.Products
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToListAsync();
            return product;
        }

        public async Task<bool> Update(int Id, AddProductDto productDto)
        {
            var product = await Find(Id);
            if (product != null)
            {
                var products = _mapper.Map(productDto, product);
                _context.Products.Update(products);
                await _context.SaveChangesAsync();
                return false;
            }
            return false;
        }
    }
}
