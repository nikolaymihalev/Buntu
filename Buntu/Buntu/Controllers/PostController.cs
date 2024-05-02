using Buntu.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Buntu.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        [HttpGet]
        public async Task<IActionResult> Home(int currentPage = 1)
        {
            var model = await postService.GetPostsForPageAsync(User.Id(), currentPage);

            return View(model);
        }
    }
}
