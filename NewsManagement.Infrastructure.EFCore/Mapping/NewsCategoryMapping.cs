using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsManagement.Domain.NewsCategoryAgg;

namespace NewsManagement.Infrastructure.EFCore.Mapping
{
    public class NewsCategoryMapping :IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.ToTable("NewsCategories");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasMany(x => x.News)
           .WithOne(x => x.Category)
           .HasForeignKey(x => x.CategoryId);

        }
    }
}
