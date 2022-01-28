using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManagement.Domain.NewsAgg;

namespace NewsManagement.Infrastructure.EFCore.Mapping
{
    public class NewsMapping : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(2000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.Metadescription).HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
