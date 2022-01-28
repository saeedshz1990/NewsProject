using _0_Framework.Application;
using _01_NewsProjectQuery.Contracts.News;
using _01_NewsProjectQuery.Contracts.NewsCategory;
using Microsoft.EntityFrameworkCore;
using NewsManagement.Domain.NewsAgg;
using NewsManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_NewsProjectQuery.Query
{
    public class NewsCategoryQuery : INewsCategoryQuery
    {

        private readonly NewsManagementContext _context;

        public NewsCategoryQuery(NewsManagementContext context)
        {
            _context = context;
        }

        public List<NewsCategoryQueryModel> GetNewsCategories()
        {
            return _context.NewsCategories
                            .Include(x => x.News)
                            .Select(x => new NewsCategoryQueryModel
                            {
                                Name = x.Name,
                                Picture = x.Picture,
                                PictureAlt = x.PictureAlt,
                                PictureTitle = x.PictureTitle,
                                Slug = x.Slug,
                                NewsCount = x.News.Count
                            }).ToList();
        }

        public NewsCategoryQueryModel GetNewsCategory(string slug)
        {
            var newsCategory = _context.NewsCategories
                .Include(x => x.News)
                .Select(x => new NewsCategoryQueryModel
                {
                    Slug = x.Slug,
                    Name = x.Name,
                    Description = x.Description,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    NewsCount = x.News.Count,
                    News = MapNews(x.News)
                }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(newsCategory.Keywords))
                newsCategory.KeywordList = newsCategory.Keywords.Split(",").ToList();

            return newsCategory;
        }

        private static List<NewsQueryModel> MapNews(List<News> articles)
        {
            return articles
                .Select(x => new NewsQueryModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
            }).ToList();
        }
    }
}
