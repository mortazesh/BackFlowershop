using FlowerShop.Application.Dto.Response;
using FlowerShop.Application.Dto.Shop;
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
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _shop;
        public ShopController(IShopRepository shop)
        {
            _shop = shop;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _shop.Get(Id);
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
            var result = await _shop.GetAll();
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
        public async Task<IActionResult> Post(AddShopDto model)
        {
            await _shop.Add(model);
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
            var result = await _shop.Delete(Id);
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
        public async Task<IActionResult> Put(int Id, AddShopDto model)
        {
            var result = await _shop.Update(Id, model);
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
