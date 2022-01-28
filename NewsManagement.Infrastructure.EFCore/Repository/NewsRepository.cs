using _0_Framework.Application;
using _0_FrameWork.Infrasutructure;
using Microsoft.EntityFrameworkCore;
using NewsManagement.Application.Contracts.News;
using NewsManagement.Domain.NewsAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsManagement.Infrastructure.EFCore.Repository
{
    public class NewsRepository : RepositoryBase<long, News>, INewsRepository
    {
        private readonly NewsManagementContext _context;

        public NewsRepository(NewsManagementContext context) : base (context)
        {
            _context = context;
        }

        public EditNews GetDetails(long id)
        {
            return _context
                .News
                .Select( x=> new EditNews
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                KeyWords = x.KeyWords,
                Metadescription = x.Metadescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title

            }).FirstOrDefault(x=>x.Id==id);
        }

        public News GetWithCategory(long id)
        {
            return _context.News
                .Include(x => x.Category)
                .FirstOrDefault(x=>x.Id==id);
        }

        public List<NewsViewModel> Search(NewsSearchModel searchModel)
        {
            var query = _context.News.Select(x => new NewsViewModel
            {
                Id = x.Id,
                Title = x.Title,
                PublisDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + ".....",
                Picture=x.Picture,
                CategoryId = x.CategoryId,
                Category=x.Category.Name
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
