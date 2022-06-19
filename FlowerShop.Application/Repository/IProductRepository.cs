using FlowerShop.Application.Dto.Product;
using FlowerShop.Domain.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Repository
{
    public interface IProductRepository
    {
        Task<ProductDto> Get(int Id);
        Task Add(AddProductDto productDto);
        Task<bool> Delete(int Id);
        Task<bool> Update(int Id,AddProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<Product> Find(int Id);
    }
}
