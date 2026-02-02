using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TPfinal_BlogAPI.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }

    [Required, MaxLength(100)]
    public string Author { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [JsonIgnore]
    public Article Article { get; set; }
}
