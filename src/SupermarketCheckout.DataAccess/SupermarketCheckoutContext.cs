
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupermarketCheckoutContext).Assembly);
        }
    }
}
