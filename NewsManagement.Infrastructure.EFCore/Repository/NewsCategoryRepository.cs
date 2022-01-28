using _0_Framework.Application;
using _0_FrameWork.Infrasutructure;
using Microsoft.EntityFrameworkCore;
using NewsManagement.Application.Contracts.NewsCategory;
using NewsManagement.Domain.NewsCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace NewsManagement.Infrastructure.EFCore.Repository
{
    public class NewsCategoryRepository : RepositoryBase<long, NewsCategory>, INewsCategoryRepository
    {
        private readonly NewsManagementContext _context;

        public NewsCategoryRepository (NewsManagementContext context) : base(context)
        {
            _context = context;
        }

        public EditNewsCategory GetDetails(long id)
        {
            return _context.NewsCategories.Select(x=> new EditNewsCategory
            {
                Id = x.Id,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<NewsCategoryViewModel> GetNewsCategories()
        {
            return _context.NewsCategories
            .Select(x => new NewsCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();    
        }

        public string GetSlugBy(long id)
        {
            return _context.NewsCategories
                .Select(x => new { x.Id, x.Slug })
               .FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<NewsCategoryViewModel> Search(NewsCategorySearchModel searchModel)
        {
            var query = _context.NewsCategories
                .Include(x => x.News)
                .Select(x => new NewsCategoryViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    CreationDate = x.CreationDate.ToFarsi(),
                    NewsCount = x.News.Count
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
