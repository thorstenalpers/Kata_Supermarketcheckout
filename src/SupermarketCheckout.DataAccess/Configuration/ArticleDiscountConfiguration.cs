namespace SupermarketCheckout.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SupermarketCheckout.DataAccess.Models;

    public class ArticleDiscountConfiguration : IEntityTypeConfiguration<ArticleDiscount>
    {
        public void Configure(EntityTypeBuilder<ArticleDiscount> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.ArticleId)
                .IsRequired();

            builder.Property(e => e.NumberOfArticles)
                .IsRequired();

            builder.Property(e => e.NewPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))")
                .IsRequired();

            builder.HasIndex(b => b.ArticleId)
                .IsUnique();
        }
    }
}
