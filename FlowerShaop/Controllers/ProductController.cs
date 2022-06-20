using FlowerShop.Application.Dto.Product;
using FlowerShop.Application.Dto.Response;
using FlowerShop.Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShaop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _product.Get(Id);
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات با موفقیت انجام شد",
                IsSccees = true,
                Result = result,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "",
                        Rel = ""
                    }
                }
            });
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _product.GetAll();
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات با موفقیت انجام شد",
                IsSccees = true,
                Result = result,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "",
                        Rel = ""
                    }
                }
            });
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddProductDto model)
        {
            await _product.Add(model);
            return Ok(new ResponseDto
            {
                DisplayMessage = "عملیات با موفقیت انجام شد",
                IsSccees = true,
                links = new List<LinksDto>
                {
                    new LinksDto
                    {
                        Href = "",
                        Method = "",
                        Rel = ""
                    }
                }
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _product.Delete(Id);
            if (result)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "",
                            Rel = ""
                        }
                    }
                });
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات با موفقیت انجام نشد",
                IsSccees = true,
                links = new List<LinksDto>
                {
                  new LinksDto
                  {
                     Href = "",
                     Method = "",
                     Rel = ""
                  }
                }
            });
        }
        [HttpPut]
        public async Task<IActionResult> Put(int Id, AddProductDto model)
        {
            var result = await _product.Update(Id, model);
            if (result)
            {
                return Ok(new ResponseDto
                {
                    DisplayMessage = "عملیات با موفقیت انجام شد",
                    IsSccees = true,
                    links = new List<LinksDto>
                    {
                        new LinksDto
                        {
                            Href = "",
                            Method = "",
                            Rel = ""
                        }
                    }
                });
            }
            return BadRequest(new ResponseDto
            {
                ErrorMessage = "عملیات با موفقیت انجام نشد",
                IsSccees = true,
                links = new List<LinksDto>
                {
                  new LinksDto
                  {
                     Href = "",
                     Method = "",
                     Rel = ""
                  }
                }
            });
        }
    }
}
