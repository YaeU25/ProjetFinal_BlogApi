
using Microsoft.EntityFrameworkCore;
using TPfinal_BlogAPI.Entities;

namespace TPfinal_BlogAPI .Data;

public class BlogCotext : DbContext
{
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public BlogCotext(DbContextOptions<BlogCotext> options) : base(options) { }
}
