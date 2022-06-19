using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Application.Dto.Product
{
    public class AddProductDto
    {
        public string Name { private set; get; }
        public string Description { get; private set; }
        public int Price { private set; get; }
        public int Count { private set; get; }
    }
}
