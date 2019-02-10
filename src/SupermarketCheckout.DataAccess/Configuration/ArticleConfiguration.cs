using System;
namespace SupermarketCheckout.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SupermarketCheckout.DataAccess.Models;

    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("ArticleID")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(b => b.Name)
                .IsUnique();
        }
    }
}
