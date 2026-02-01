namespace TPfinal_BlogAPI.DTOs;

public class CreateArticleDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
