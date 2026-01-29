
using Microsoft.EntityFrameworkCore;
using TPfinal_BlogAPI.Entities;

namespace TPfinal_BlogAPI.Data;

public class BlogContext : DbContext
{
    public virtual DbSet<Article> Articles { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

}
