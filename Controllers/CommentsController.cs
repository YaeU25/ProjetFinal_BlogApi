using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPfinal_BlogAPI.DTOs;
using TPfinal_BlogAPI.Entities;
using TPfinal_BlogAPI.Services;

namespace TPfinal_BlogAPI.Controllers
{
    [Route("api/v1/articles/{articleId}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public IActionResult GetAllByArticle(int articleId)
        {
            try
            {
                var comments = _commentService.GetAllCommentsByArticle(articleId);
                return Ok(comments);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{commentId}")]
        public IActionResult GetComment(int articleId, int commentId)
        {
            var comment = _commentService.GetById(commentId);
            if (comment == null || comment.Article_id != articleId)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(int articleId, [FromBody] CreateCommentDto payload)
        {
            var comment = _commentService.Creat(articleId, payload);
            return CreatedAtAction(nameof(GetComment), new { commentId = comment.Id }, comment);
        }

        [HttpDelete("{commentId}")]
        public IActionResult Delete(int commentId)
        {
            var deleted = _commentService.Delete(commentId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
