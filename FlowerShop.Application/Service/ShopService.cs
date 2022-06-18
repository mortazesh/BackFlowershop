using AutoMapper;
using FlowerShop.Application.Dto.Shop;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model.Shops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Service
{
    public class ShopService: IShopRepository
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public ShopService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(AddShopDto shopDto)
        {
            var shop = _mapper.Map<Shop>(shopDto);
            await _context.Shops.AddAsync(shop);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var shop = await Find(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Shop> Find(int Id)
        {
            var shop = await _context.Shops.FindAsync(Id);
            return shop != null ? shop : null;
        }

        public async Task<ShopDto> Get(int id)
        {
            var shop = await _context.Shops
                .Where(s => s.Id == id)
                .Include(s => s.Seos)
                .FirstOrDefaultAsync();
            return new ShopDto
            {
                Id = shop.Id,
                Description = shop.Description,
                Name = shop.Name,
                UrlImage = shop.UrlImage,
                seo = new Dto.Seos.SeoDto
                {
                    Description = shop.Seos.Description,
                    Created = shop.Seos.Created
                }
            };
        }

        public async Task<IEnumerable<ShopDto>> GetAll()
        {
            var shops = await _context.Shops
                .Select(s => new ShopDto
                {
                    UrlImage = s.UrlImage,
                    Name = s.Name
                }).ToListAsync();
            return shops;
        }

        public async Task<bool> Update(AddShopDto shopDto)
        {
            var shop = await Find(shopDto.Id);
            if (shop != null)
            {
                var shops = _mapper.Map(shopDto, shop);
                _context.Shops.Update(shops);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
