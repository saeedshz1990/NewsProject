using _0_Framework.Application;
using _01_NewsProjectQuery.Contracts.Comment;
using _01_NewsProjectQuery.Contracts.News;
using CommentManagment.Infrastructure.EFCore;
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
        private readonly CommnetContext _commnetContext;


        public NewsQuery(NewsManagementContext context, CommnetContext commnetContext)
        {
            _context = context;
            _commnetContext = commnetContext;
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

            var comments = _commnetContext.Comments
               .Where(x => !x.IsCanceled)
               .Where(x => x.IsConfirmed)
               .Where(x => x.OwnerRecordId == news.Id)
               .Select(x => new CommentQueryModel
               {
                   Id = x.Id,
                   Message = x.Message,
                   Name = x.Name,
                   ParentId = x.ParentId,
                   CreationDate = x.CreationDate.ToFarsi()
               }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                    comment.parentName = comments
                        .FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
            }

            news.Comments = comments;


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
