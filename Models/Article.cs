using System.ComponentModel.DataAnnotations;

namespace TPfinal_BlogAPI.Entities;

public class Article
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public List<Comment> Comments { get; set; } = new List<Comment>();

}
