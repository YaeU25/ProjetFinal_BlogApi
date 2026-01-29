
using Microsoft.AspNetCore.Mvc;
using TPfinal_BlogAPI.Data;
using TPfinal_BlogAPI.DTOs;
using TPfinal_BlogAPI.Entities;

namespace TPfinal_BlogAPI.Services;

public class CommentService
{
    private readonly BlogCotext _context;
    public CommentService(BlogCotext context)
    {
        _context = context;
    }

    public IEnumerable<Comment> GetAllCommentsByArticle(int articleId)
    {
        return _context.Comments
            .Where(c => c.Article_id == articleId)
            .ToList();
    }
    public Comment Creat(int articleId, CreateCommentDto payload)
    {
        var commentAuthor = payload.Author;
        var commentContent = payload.Content;
        var commentCreatedAt = payload.CreatedAt;

        var newComment = new Comment()
        {
            Author = commentAuthor,
            Content = commentContent,
            CreatedAt = commentCreatedAt
        };

        _context.Comments.Add(newComment);
        _context.SaveChanges();

        return newComment;
    }

    public Comment? GetById(int id)
    {
        return _context.Comments.FirstOrDefault(c => c.Id == id);
    }
    public bool Delete(int id)
    {
        var commentFound = _context.Comments.FirstOrDefault(c => c.Id == id);
        if (commentFound == null) return false;

        _context.Comments.Remove(commentFound);
        _context.SaveChanges();
        return true;
    }
}
