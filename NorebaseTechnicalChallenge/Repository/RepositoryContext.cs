using Microsoft.EntityFrameworkCore;
using NorebaseTechnicalChallenge.Models;

namespace NorebaseTechnicalChallenge.Repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { ArticleId = 1,  LikeCount = 0 },
                new Article { ArticleId = 2, LikeCount = 0 },
                new Article { ArticleId = 3, LikeCount = 0 },
                new Article { ArticleId = 4, LikeCount = 0 },
                new Article { ArticleId = 5, LikeCount = 0 },
                new Article { ArticleId = 6, LikeCount = 0 }
            );
        }

    }
}
