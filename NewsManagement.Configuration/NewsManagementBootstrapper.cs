using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsManagement.Application;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Application.Contracts.NewsCategory;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Domain.NewsCategoryAgg;
using NewsManagement.Infrastructure.EFCore;
using NewsManagement.Infrastructure.EFCore.Repository;

namespace NewsManagement.Infrastructure.Configuration
{
    public class NewsManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,
            string connectionString)
        {
            services.AddTransient<INewsApplication, NewsApplication>();
            services.AddTransient<INewsRepository,NewsRepository>();

            services.AddTransient<INewsCategoryApplication, NewsCategoryApplication>();
            services.AddTransient<INewsCategoryRepository, NewsCategoryRepository>();

            services.AddDbContext<NewsManagementContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
