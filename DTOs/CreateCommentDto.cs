namespace TPfinal_BlogAPI.DTOs;

public class CreateCommentDto
{
    public int Article_id { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
