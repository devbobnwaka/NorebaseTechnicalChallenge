using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorebaseTechnicalChallenge.Contracts;

namespace NorebaseTechnicalChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public ArticlesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("{articleId}/likes")]
        public async Task<IActionResult> GetLikeCount(int articleId)
        {
            var likeCount = await _likeService.GetLikes(articleId);
            return Ok(new { Likes = likeCount });
        }

        [HttpPost("{articleId}/like")]
        public async Task<IActionResult> LikeArticle(int articleId)
        {
            await _likeService.IncrementLike(articleId);
            return Ok();
        }
    }
}
