
namespace SupermarketCheckout.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using SupermarketCheckout.DataAccess.Models;

    public class SupermarketCheckoutContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDiscount> ArticleDiscounts { get; set; }
        public DbSet<ArticlePrice> ArticlePrices { get; set; }

        public SupermarketCheckoutContext(DbContextOptions<SupermarketCheckoutContext> options)
            : base(options)
        {
            this.ArticleDiscounts.Include(e => e.Article);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var apple = new Article
            {
                Id = 1,
                Name = "Apple"
            };
            var banana = new Article
            {
                Id = 2,
                Name = "Banana"
            };
            var peach = new Article
            {
                Id = 3,
                Name = "Peach"
            };

            modelBuilder.Entity<Article>().HasData(
                apple, banana, peach
            );
            modelBuilder.Entity<ArticlePrice>().HasData(
                new ArticlePrice
                {
                    Id = 1,
                    UnitPrice = 50,
                    ArticleId = banana.Id
                },
                new ArticlePrice
                {
                    Id = 2,
                    UnitPrice = 30,
                    ArticleId = apple.Id
                },
                new ArticlePrice
                {
                    Id = 3,
                    UnitPrice = 60,
                    ArticleId = peach.Id
                }
            );
            modelBuilder.Entity<ArticleDiscount>().HasData(
                 new ArticleDiscount
                 {
                     Id = 1,
                     NewPrice = 130,
                     NumberOfArticles = 3,
                     ArticleId = banana.Id
                 },
                 new ArticleDiscount
                 {
                     Id = 2,
                     NewPrice = 45,
                     NumberOfArticles = 2,
                     ArticleId = apple.Id
                 }
             );
        }
    }

}
