using FlowerShop.Application.Dto.Shop;
using FlowerShop.Domain.Model.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Repository
{
    public interface IShopRepository
    {
        Task Add(AddShopDto shopDto);
        Task<bool> Delete(int id);
        Task<bool> Update(AddShopDto shopDto);
        Task<IEnumerable<ShopDto>> GetAll();
        Task<ShopDto> Get(int id);
        Task<Shop> Find(int Id);
    }
}
