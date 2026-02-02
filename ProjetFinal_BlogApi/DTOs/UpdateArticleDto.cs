namespace TPfinal_BlogAPI.DTOs;

public class UpdateArticleDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime UpdatedAt { get; set; }
}
