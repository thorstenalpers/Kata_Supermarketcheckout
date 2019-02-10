namespace SupermarketCheckout.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SupermarketCheckout.DataAccess.Models;

    public class ArticlePriceConfiguration : IEntityTypeConfiguration<ArticlePrice>
    {
        public void Configure(EntityTypeBuilder<ArticlePrice> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ArticlePriceID");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
        }
    }
}
