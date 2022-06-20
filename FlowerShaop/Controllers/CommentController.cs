using FlowerShop.Application.Dto.Comment;
using FlowerShop.Application.Dto.Response;
using FlowerShop.Application.Repository;
using FlowerShop.Domain.Model.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShaop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _comment;
        private readonly UserManager<User> _userManager;
        public CommentController(ICommentRepository comment, UserManager<User> userManager)
        {
            _comment = comment;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get(AddCommentDto model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.UserId = user.Id;
            await _comment.Add(model);
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _comment.GetAll();
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
    }
}
