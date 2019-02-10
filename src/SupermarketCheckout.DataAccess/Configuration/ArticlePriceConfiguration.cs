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
            builder.Property(e => e.Id)
                .HasColumnName("ArticlePriceID")
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))")
                .IsRequired();

            builder.Property(e => e.ArticleId)
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .IsRequired();

            builder.HasIndex(b => b.ArticleId)
                .IsUnique();
        }
    }
}
