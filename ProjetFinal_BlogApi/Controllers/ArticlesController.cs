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
        private readonly ILogger<ArticlesController> _logger;
        public ArticlesController(ArticleService articleService, ILogger<ArticlesController> logger)
        {
            _articleService = articleService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetArticles(int page = 1, int pageSize = 5)
        {
            try
            {
                var result = _articleService.GetArticles(page, pageSize);
                _logger.LogInformation("GetArticles returned {Count} articles", result.Count());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting articles");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{articleId}")]
        public IActionResult GetArticle(int articleId)
        {
            var article = _articleService.GetById(articleId);
            if (article == null)
            {
                _logger.LogWarning("Article ID : id={Id} not found", articleId);
                return NotFound();
            }
            _logger.LogInformation("GetArticle returned articles ID : id={Id}", articleId);
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
