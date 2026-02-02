using Microsoft.EntityFrameworkCore;
using TPfinal_BlogAPI.Data;
using TPfinal_BlogAPI.Entities;
using TPfinal_BlogAPI.Services;

namespace TPfinal_BlogAPI.Tests;

public class ArticleServiceTests
{
    private BlogContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new BlogContext(options);
    }

    [Fact]
    public void GetArticles_ReturnsCorrectPage()
    {
        // Arrange
        var db = CreateDb();

        for (int i = 1; i <= 20; i++)
        {
            db.Articles.Add(new Article { Title = $"Article {i}", Content = "Test" });
        }
        db.SaveChanges();

        var service = new ArticleService(db);

        // Act
        var result = service.GetArticles(page: 2, pageSize: 5).ToList();

        // Assert
        Assert.Equal(5, result.Count);
        Assert.Equal("Article 6", result[0].Title);
        Assert.Equal("Article 10", result[4].Title);
    }
}
