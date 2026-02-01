using TPfinal_BlogAPI.Data;
using TPfinal_BlogAPI.DTOs;
using TPfinal_BlogAPI.Entities;

namespace TPfinal_BlogAPI.Services;

public class ArticleService
{
    private readonly BlogContext _context;
    public ArticleService(BlogContext context)
    {
        _context = context;
    }

    public IEnumerable<CreateArticleDto> GetArticles()
    {
        var query = _context.Articles.AsQueryable();
        return query
            .Select(a => new CreateArticleDto
            {
                Title = a.Title,
                Content = a.Content
            })
            .ToList();
    }

    public Article? GetById(int id)
    {
        return _context.Articles.FirstOrDefault(a => a.Id == id);
    }

    public Article Creat(CreateArticleDto payload)
    {
        var articleTitle = payload.Title;
        var articleContent = payload.Content;
        var articleCreatedAt = payload.CreatedAt;

        var newArticle = new Article()
        {
            Title = articleTitle,
            Content = articleContent,
            CreatedAt = DateTime.Now
        };

        _context.Articles.Add(newArticle);
        _context.SaveChanges();

        return newArticle;
    }

    public IEnumerable<CreateArticleDto> Search(string? title, string? content)
    {
        var query = _context.Articles.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(a => a.Title.Contains(title));

        if (!string.IsNullOrWhiteSpace(content))
            query = query.Where(a => a.Content.Contains(content));

        return query
            .Select(a => new CreateArticleDto
            {
                Title = a.Title,
                Content = a.Content
            })
            .ToList();
    }

    public bool Update(int id, UpdateArticleDto payload)
    {
        var articleFound = _context.Articles.FirstOrDefault(a => a.Id == id);
        if (articleFound == null) return false;
        if (!string.IsNullOrEmpty(payload.Title))
        {
            articleFound.Title = payload.Title;
        }
        if (!string.IsNullOrEmpty(payload.Content))
        {
            articleFound.Content = payload.Content;
        }
        articleFound.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var articleFound = _context.Articles.FirstOrDefault(a => a.Id == id);
        if (articleFound == null) return false;

        _context.Articles.Remove(articleFound);
        _context.SaveChanges();
        return true;
    }
}

