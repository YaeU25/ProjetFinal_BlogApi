using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPfinal_BlogAPI.Entities;
public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Article")]
    public int Article_id { get; set; }

    [Required, MaxLength(100)]
    public string Author { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public virtual Article Article { get; set; }
}
