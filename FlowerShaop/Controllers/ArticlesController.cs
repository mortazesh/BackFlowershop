using FlowerShop.Application.Dto.Articles;
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
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesRepository _articles;
        public ArticlesController(IArticlesRepository articles)
        {
            _articles = articles;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _articles.Get(Id);
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
            var result = await _articles.GetAll();
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
        public async Task<IActionResult> Post(AddArticlesDto model)
        {
            await _articles.Add(model);
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
            var result = await _articles.Delete(Id);
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
        public async Task<IActionResult> Put(int Id,AddArticlesDto model)
        {
            var result = await _articles.Update(Id,model);
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
