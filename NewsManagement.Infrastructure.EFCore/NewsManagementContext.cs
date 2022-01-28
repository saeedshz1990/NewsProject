using Microsoft.EntityFrameworkCore;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Domain.NewsCategoryAgg;
using NewsManagement.Infrastructure.EFCore.Mapping;

namespace NewsManagement.Infrastructure.EFCore
{
    public class NewsManagementContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        

        public NewsManagementContext(DbContextOptions<NewsManagementContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(NewsCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
