using _01_NewsProjectQuery.Contracts.News;
using _01_NewsProjectQuery.Contracts.NewsCategory;
using _01_NewsProjectQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsManagement.Application;
using NewsManagement.Application.Contract.Slide;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Application.Contracts.NewsCategory;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Domain.NewsCategoryAgg;
using NewsManagement.Domain.SlideAgg;
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

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<INewsQuery, NewsQuery>();
            services.AddTransient<INewsCategoryQuery, NewsCategoryQuery>();


            services.AddDbContext<NewsManagementContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
