using Microsoft.AspNetCore.Mvc;
using TPfinal_BlogAPI.DTOs;
using TPfinal_BlogAPI.Services;

namespace TPfinal_BlogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleService _articleService;
        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            try
            {
                var result = _articleService.GetArticles();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{articleId}")]
        public IActionResult GetArticle(int articleId)
        {
            var article = _articleService.GetById(articleId);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public IActionResult CreateArticle([FromBody] CreateArticleDto payload)
        {
            var article = _articleService.Creat(payload);
            return CreatedAtAction(nameof(GetArticle), new { articleId = article.Id }, article);
        }

        [HttpPut("{articleId}")]
        public IActionResult PutArticle(int articleId, [FromBody] UpdateArticleDto payload)
        {
            var updated = _articleService.Update(articleId, payload);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{articleId}")]
        public IActionResult Delete(int articleId)
        {
            var deleted = _articleService.Delete(articleId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchArticles([FromQuery] string? title, [FromQuery] string? content)
        {
            var results = _articleService.Search(title, content);
            if (!results.Any())
                return NotFound();
            return Ok(results);

        }
    }
}
