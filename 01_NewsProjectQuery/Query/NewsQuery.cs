using _0_Framework.Application;
using _01_NewsProjectQuery.Contracts.News;
using Microsoft.EntityFrameworkCore;
using NewsManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_NewsProjectQuery.Query
{
    public class NewsQuery : INewsQuery
    {
        private readonly NewsManagementContext _context;

        public NewsQuery(NewsManagementContext context)
        {
            _context = context;
        }

        public NewsQueryModel GetNewsDetails(string slug)
        {
            var news = _context.News
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new NewsQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    CanonicalAddress = x.CanonicalAddress,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Slug = x.Slug,
                    Description = x.Description,
                    MetaDescription = x.Metadescription,
                    ShortDescription = x.ShortDescription,
                    Keywords = x.KeyWords
                }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(news.Keywords))
                news.KeywordList = news.Keywords.Split(",").ToList();

            return news;
        }

        public List<NewsQueryModel> LatestNews()
        {
            return _context.News
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new NewsQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,

                }).ToList();
        }
    }
}
